using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FFMpeg.Probe
{
    public interface IProbe
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<IMetadata> GetMetadataAsync(Uri url);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<IMetadata> GetMetadataAsync(FileInfo fileInfo);
    }
}
