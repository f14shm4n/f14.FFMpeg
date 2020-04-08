using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe.Internal
{
    internal class AudioStreamMetadata : IAudioStreamMetadata
    {
        public string Format { get; set; } = string.Empty;

        public int BitRate { get; set; }

        public long Size { get; set; }

        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Audio stream metadata:");
            sb.AppendLine($"- {nameof(Format)}: {Format}");
            sb.AppendLine($"- {nameof(BitRate)}: {BitRate}");
            sb.AppendLine($"- {nameof(Size)}: {Size}");
            sb.AppendLine($"- {nameof(Duration)}: {Duration.TotalSeconds}");
            return sb.ToString();
        }
    }
}
