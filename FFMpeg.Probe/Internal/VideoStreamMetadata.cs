using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FFMpeg.Probe.Internal
{
    internal class VideoStreamMetadata : IVideoStreamMetadata
    {
        public string Format { get; set; } = string.Empty;

        public int Height { get; set; }

        public int Width { get; set; }

        public string Ratio { get; set; } = string.Empty;

        public int BitRate { get; set; }

        public long Size { get; set; }

        public double Fps { get; set; }

        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Video stream metadata:");
            sb.AppendLine($"- {nameof(Format)}: {Format}");
            sb.AppendLine($"- {nameof(BitRate)}: {BitRate}");
            sb.AppendLine($"- {nameof(Size)}: {Size}");
            sb.AppendLine($"- {nameof(Fps)}: {Fps}");
            sb.AppendLine($"- Resolution: {Width}x{Height}");
            sb.AppendLine($"- {nameof(Ratio)}: {Ratio}");
            sb.AppendLine($"- {nameof(Duration)}: {Duration.TotalSeconds}");
            return sb.ToString();
        }
    }
}
