using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FFMpeg.Probe.Internal.Json
{
    internal class ProbeMetadata
    {
        [JsonPropertyName("streams")]
        public List<ProbeStream>? Streams { get; set; }

        [JsonPropertyName("format")]
        public ProbeFormat? Format { get; set; }
    }
}
