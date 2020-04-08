using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FFMpeg.Probe.Internal.Json
{
    internal class ProbeStream
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("codec_name")]
        public string CodecName { get; set; } = string.Empty;

        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; } = string.Empty;

        [JsonPropertyName("profile")]
        public string Profile { get; set; } = string.Empty;

        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; } = string.Empty;

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonPropertyName("r_frame_rate")]
        public string FrameRate { get; set; } = string.Empty;

        [JsonPropertyName("tags")]
        public ProbeTags? Tags { get; set; }
    }
}
