using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Probe.Exceptions
{
    public class FFProbeInvalidSourceException : Exception
    {
        public FFProbeInvalidSourceException(string message) : base(message)
        {
        }

        public FFProbeInvalidSourceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
