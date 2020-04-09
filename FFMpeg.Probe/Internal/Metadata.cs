using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe.Internal
{
    internal class Metadata : IMetadata
    {
        private readonly List<IVideoStreamMetadata> _videoStreams = new List<IVideoStreamMetadata>();
        private readonly List<IAudioStreamMetadata> _audioStreams = new List<IAudioStreamMetadata>();

        public TimeSpan Duration { get; set; }
        public IReadOnlyList<IVideoStreamMetadata> VideoStreams => _videoStreams;
        public IReadOnlyList<IAudioStreamMetadata> AudioStreams => _audioStreams;

        public void AddVideoStream(IVideoStreamMetadata videoStream) => _videoStreams.Add(videoStream);
        public void AddAudioStream(IAudioStreamMetadata audioStream) => _audioStreams.Add(audioStream);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("= Metadata =");
            if (VideoStreams != null)
            {
                PrintStreamInfo("Video streams", VideoStreams);
            }
            if (AudioStreams != null)
            {
                PrintStreamInfo("Audio streams", AudioStreams);
            }

            return sb.ToString();

            void PrintStreamInfo(string tag, IEnumerable objects)
            {
                sb.AppendLine($"== {tag} ==");
                foreach (var o in objects)
                {
                    sb.AppendLine(o.ToString());
                }
            }
        }
    }
}
