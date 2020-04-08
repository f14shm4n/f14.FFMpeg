using FFMpeg.Arguments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FFMpeg
{
    /// <summary>
    /// Represents basic logic for the FFMpeg wrapper.
    /// </summary>
    public interface IFFMpeg
    {
        /// <summary>
        /// Executes FFMpeg with specified arguments.
        /// </summary>
        /// <typeparam name="T">Type of media info implementation.</typeparam>
        /// <param name="argumentBuilder"></param>
        /// <returns></returns>
        Task<IMediaInfo> ExecuteAsync(IArgumentBuilder argumentBuilder);  
    }
}
