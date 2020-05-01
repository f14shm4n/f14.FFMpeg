using System;
using System.Globalization;
using System.Threading.Tasks;
using Instances;
using System.IO;
using System.Text.Json;
using FFMpeg.Probe.Internal;
using FFMpeg.Probe.Internal.Json;
using FFMpeg.Probe.Helpers;
using System.Collections.Generic;
using System.Linq;
using FFMpeg.Probe.Exceptions;

namespace FFMpeg.Probe
{
    public class FFProbe : IProbe
    {
        private const int BitsInMegabytes = 8388608;
        private const string FFProbeArgumentsFormat = "-v quiet -print_format json -show_streams \"{0}\"";
        private readonly int _outputCapacity;
        private readonly string _ffprobePath;

        public FFProbe(string ffprobePath, int outputCapacity = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(ffprobePath))
            {
                throw new ArgumentException($"Invalid path to the FFProbe. Path: '{ffprobePath}'.", nameof(ffprobePath));
            }
            _ffprobePath = ffprobePath;
            _outputCapacity = outputCapacity;
        }

        public Task<IMetadata> GetMetadataAsync(Uri url)
        {
            if (!url.IsWellFormedOriginalString())
            {
                throw new UriFormatException($"Invalid url. Url: '{url}'.");
            }
            return GetMetadataInternalAsync(url.ToString());
        }

        public Task<IMetadata> GetMetadataAsync(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException($"File not found.", fileInfo.FullName);
            }
            return GetMetadataInternalAsync(fileInfo.FullName);
        }

        private async Task<IMetadata> GetMetadataInternalAsync(string pathToMedia)
        {
            var instance = new Instance(_ffprobePath, string.Format(FFProbeArgumentsFormat, pathToMedia))
            {
                DataBufferCapacity = _outputCapacity
            };
            await instance.FinishedRunning();
            var output = string.Join("", instance.OutputData);
            return ParseProbeOutput(output);
        }

        private Metadata ParseProbeOutput(string probeOutput)
        {
            var probeMetadata = JsonSerializer.Deserialize<ProbeMetadata>(probeOutput);

            if (probeMetadata.Streams == null || probeMetadata.Streams.Count == 0)
            {
                throw new FFProbeInvalidSourceException($"No video or audio streams could be detected.");
            }

            var metadata = new Metadata();

            ParseVideoStreams(metadata, probeMetadata.Streams?.Where(s => s.CodecType == "video").ToList());
            ParseAudioStreams(metadata, probeMetadata.Streams?.Where(s => s.CodecType == "audio").ToList());

            return metadata;
        }

        private void ParseVideoStreams(Metadata metadata, IReadOnlyCollection<ProbeStream>? streams)
        {
            if (streams?.Count > 0)
            {
                foreach (var stream in streams)
                {
                    try
                    {
                        var bitRate = Convert.ToInt32(stream.BitRate, CultureInfo.InvariantCulture);
                        var fr = stream.FrameRate.Split('/');
                        var commonDenominator = FFProbeHelper.Gcd(stream.Width, stream.Height);
                        var duration = FFProbeHelper.ParseDuration(stream.Duration);

                        var vsmd = new VideoStreamMetadata
                        {
                            Format = stream.CodecName,
                            Fps = Math.Round(Convert.ToDouble(fr[0], CultureInfo.InvariantCulture) / Convert.ToDouble(fr[1], CultureInfo.InvariantCulture), 3),
                            Bitrate = bitRate,
                            Height = stream.Height,
                            Width = stream.Width,
                            Ratio = stream.Width / commonDenominator + ":" + stream.Height / commonDenominator,
                            Size = (long)Math.Round(bitRate * duration.TotalSeconds / 8),
                            Duration = duration
                        };

                        metadata.AddVideoStream(vsmd);

                        metadata.Duration = Max(metadata.Duration, duration);
                    }
                    catch (Exception)
                    {
                        // TODO: Log ex
                    }
                }
            }
        }

        private void ParseAudioStreams(Metadata metadata, IReadOnlyCollection<ProbeStream>? streams)
        {
            if (streams?.Count > 0)
            {
                foreach (var stream in streams)
                {
                    try
                    {
                        var bitRate = Convert.ToInt32(stream.BitRate, CultureInfo.InvariantCulture);
                        var duration = FFProbeHelper.ParseDuration(stream.Duration);

                        var asmd = new AudioStreamMetadata
                        {
                            Format = stream.CodecName,
                            Bitrate = bitRate,
                            Size = (long)Math.Round(bitRate * duration.TotalSeconds / 8),
                            Duration = duration
                        };

                        metadata.AddAudioStream(asmd);

                        metadata.Duration = Max(metadata.Duration, duration);
                    }
                    catch (Exception)
                    {
                        // TODO: Log ex
                    }
                }
            }
        }

        private static TimeSpan Max(TimeSpan x, TimeSpan y) => x > y ? x : y;
    }
}
