using System.ComponentModel;

namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents video codec parameter
    /// </summary>
    public class VideoCodecArgument : IArgument
    {
        private readonly string? _codec;
        private readonly int _bitrate;
        private readonly bool _includeYUV;

        /// <summary>
        /// Creates new video codec argument.
        /// </summary>
        /// <param name="codec">Video codec.</param>
        /// <param name="includeYUV">Include color space arg: '-pix_fmt yuv420p'</param>
        public VideoCodecArgument(string codec, bool includeYUV = true)
        {
            _codec = codec;
            _includeYUV = includeYUV;
        }

        public VideoCodecArgument(int bitrate, bool includeYUV = true)
        {
            _bitrate = bitrate;
            _includeYUV = includeYUV;
        }
        /// <summary>
        /// Creates new video codec argument.
        /// </summary>
        /// <param name="codec">Video codec.</param>
        /// <param name="bitrate">Video bitrate in kBit/s</param>
        /// <param name="includeYUV">Include color space arg: '-pix_fmt yuv420p'</param>
        public VideoCodecArgument(string codec, int bitrate, bool includeYUV = true)
        {
            _codec = codec;
            _bitrate = bitrate;
            _includeYUV = includeYUV;
        }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            var arguments = string.Empty;

            if (!string.IsNullOrWhiteSpace(_codec))
            {
                arguments = $"-c:v {_codec} ";
            }

            if (_includeYUV)
            {
                arguments += "-pix_fmt yuv420p ";
            }

            if (_bitrate != default)
            {
                arguments += $"-b:v {_bitrate}k";
            }

            return arguments;
        }
    }
}
