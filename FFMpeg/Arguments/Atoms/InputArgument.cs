using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public IReadOnlyList<string> Sources => new ReadOnlyCollection<string>(_sources);

        /// <inheritdoc/>
        public string GetStringValue()
        {
            return string.Join(" ", _sources.Select(v => $"-i \"{v}\""));
        }
    }
}
