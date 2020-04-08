using System;
using System.IO;

namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents output parameter
    /// </summary>
    public class OutputArgument : IArgument
    {
        public OutputArgument(FileInfo value) => Destination = value.FullName;

        public OutputArgument(Uri value) => Destination = value.AbsolutePath;

        public string Destination { get; }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            return $"\"{Destination}\"";
        }
    }
}
