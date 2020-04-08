using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg
{
    public class MediaInfo : IMediaInfo
    {
        public string DestinationPath { get; set; } = string.Empty;
    }
}
