using System;
using System.IO;
using System.Linq;

namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents input parameter
    /// </summary>
    public class InputArgument : IArgument
    {
        private readonly string[] _sources;

        public InputArgument(params FileInfo[] values)
        {
            _sources = values.Select(v => v.FullName).ToArray();
        }

        public InputArgument(params Uri[] values)
        {
            _sources = values.Select(v => v.AbsoluteUri).ToArray();
        }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            return string.Join(" ", _sources.Select(v => $"-i \"{v}\""));
        }
    }
}
