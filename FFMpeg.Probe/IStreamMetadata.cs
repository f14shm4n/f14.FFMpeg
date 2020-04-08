using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe
{
    public interface IStreamMetadata
    {
        string Format { get; }
        int BitRate { get; }
        long Size { get; }
        TimeSpan Duration { get; }
    }
}
