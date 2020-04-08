using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FFMpeg.Probe.Internal.Json
{
    internal class ProbeFormat
    {
        [JsonPropertyName("filename")]
        public string FileName { get; set; } = string.Empty;

        [JsonPropertyName("nb_streams")]
        public int StreamsCount { get; set; }

        [JsonPropertyName("nb_programs")]
        public int ProgramsCount { get; set; }

        [JsonPropertyName("format_name")]
        public string FormatShort { get; set; } = string.Empty;

        [JsonPropertyName("format_long_name")]
        public string FormatFull { get; set; } = string.Empty;

        [JsonPropertyName("start_time")]
        public string StartTime { get; set; } = string.Empty;

        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonPropertyName("size")]
        public string Size { get; set; } = string.Empty;

        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; } = string.Empty;

        [JsonPropertyName("probe_score")]
        public int ProbeScore { get; set; }

        [JsonPropertyName("tags")]
        public ProbeTags? Tags { get; set; }
    }
}
