using FFMpeg.Arguments;
using FFMpeg.Arguments.Atoms;
using Instances;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FFMpeg
{
    public class FFMpegWrapper : IFFMpeg
    {
        private readonly string _ffmpegPath;
        private Instance? _instance;

        public FFMpegWrapper(string ffmpegPath)
        {
            if (string.IsNullOrWhiteSpace(ffmpegPath))
            {
                throw new ArgumentException($"Invalid path to the FFMpeg. Path: '{ffmpegPath}'.", nameof(ffmpegPath));
            }
            _ffmpegPath = ffmpegPath;
        }

        public async Task<IMediaInfo> ExecuteAsync(IArgumentBuilder argumentBuilder)
        {
            var output = argumentBuilder.Get<OutputArgument>();
            if (output == null)
            {
                throw new InvalidOperationException($"Output argument is not set.");
            }

            if (!await RunProcessAsync(argumentBuilder, output.Destination))
            {
                throw new InvalidOperationException("Could not process the media resource.");
            }

            var mi = new MediaInfo
            {
                DestinationPath = output.Destination
            };
            return mi;
        }

        private async Task<bool> RunProcessAsync(IArgumentBuilder argumentBuilder, string destinationPath)
        {
            _instance?.Dispose();

            var arguments = argumentBuilder.Build();

            _instance = new Instance(_ffmpegPath, arguments);
            var exitCode = await _instance.FinishedRunning();

            if (!File.Exists(destinationPath) || new FileInfo(destinationPath).Length == 0)
            {
                throw new InvalidOperationException(string.Join("\n", _instance.ErrorData));
            }

            return exitCode == 0;
        }
    }
}
