using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe
{
    public interface IVideoStreamMetadata : IStreamMetadata
    {
        int Height { get; }
        int Width { get; }
        string Ratio { get; }
        double Fps { get; }
    }
}
