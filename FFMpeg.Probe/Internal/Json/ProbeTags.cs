using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FFMpeg.Probe.Internal.Json
{
    internal class ProbeTags
    {
        [JsonPropertyName("creation_time")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName("handler_name")]
        public string HandlerName { get; set; } = string.Empty;

        [JsonPropertyName("major_brand")]
        public string MajorBrand { get; set; } = string.Empty;

        [JsonPropertyName("minor_version")]
        public string MinorVersion { get; set; } = string.Empty;

        [JsonPropertyName("compatible_brands")]
        public string CompatibleBrands { get; set; } = string.Empty;
    }
}
