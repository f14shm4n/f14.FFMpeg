using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe
{
    public static class IMetadataExtensions
    {
        public static bool HasVideoAndAudio(this IMetadata source) => source.VideoStreams.Count > 0 && source.AudioStreams.Count > 0;
        public static bool HasVideo(this IMetadata source) => source.VideoStreams.Count > 0;
        public static bool HasVideoOnly(this IMetadata source) => source.VideoStreams.Count > 0 && source.AudioStreams.Count == 0;
        public static bool HasAudio(this IMetadata source) => source.AudioStreams.Count > 0;
        public static bool HasAudioOnly(this IMetadata source) => source.VideoStreams.Count == 0 && source.AudioStreams.Count > 0;
    }
}
