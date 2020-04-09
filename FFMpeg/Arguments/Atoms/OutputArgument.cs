using System;
using System.IO;

namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents output parameter
    /// </summary>
    public class OutputArgument : IArgument
    {
        private bool _overwrite;

        public OutputArgument(FileInfo value, bool overwrite = true)
        {
            Destination = value.FullName;
            _overwrite = overwrite;
        }

        public OutputArgument(Uri value, bool overwrite = true)
        {
            Destination = value.AbsolutePath;
            _overwrite = overwrite;
        }

        public string Destination { get; }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            var argument = string.Empty;
            if (_overwrite)
            {
                argument += "-y ";
            }
            argument += $"\"{Destination}\"";
            return argument;
        }
    }
}
