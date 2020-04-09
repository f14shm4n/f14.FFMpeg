using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe
{
    public interface IMetadata
    {
        TimeSpan Duration { get; }
        IReadOnlyList<IVideoStreamMetadata> VideoStreams { get; }
        IReadOnlyList<IAudioStreamMetadata> AudioStreams { get; }
    }
}
