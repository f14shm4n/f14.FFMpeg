using System;
using System.Collections.Generic;
using System.Text;

namespace FFMpeg.Arguments
{
    /// <summary>
    /// Represents basic functionality of ffmpeg arguments.
    /// </summary>
    public interface IArgument
    {
        /// <summary>
        /// String representation of the argument
        /// </summary>
        /// <returns>String representation of the argument</returns>
        string GetStringValue();
    }
}
