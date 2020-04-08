using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe
{
    public interface IMetadata
    {
        TimeSpan Duration { get; }
        public IReadOnlyCollection<IVideoStreamMetadata> VideoStreams { get; }
        public IReadOnlyCollection<IAudioStreamMetadata> AudioStreams { get; }
    }
}
