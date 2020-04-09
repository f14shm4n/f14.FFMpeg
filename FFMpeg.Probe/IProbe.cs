using FFMpeg.Probe.Exceptions;
using System;
using System.IO;
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
        /// <exception cref="FFProbeInvalidSourceException"></exception>
        /// <exception cref="UriFormatException"></exception>
        Task<IMetadata> GetMetadataAsync(Uri url);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        /// <exception cref="FFProbeInvalidSourceException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        Task<IMetadata> GetMetadataAsync(FileInfo fileInfo);
    }
}
