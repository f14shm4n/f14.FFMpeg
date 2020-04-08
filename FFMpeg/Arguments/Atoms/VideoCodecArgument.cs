namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents video codec parameter
    /// </summary>
    public class VideoCodecArgument : IArgument
    {
        private readonly VideoCodec _codec;
        private readonly int _bitrate;
        private readonly bool _includeYUV;

        public VideoCodecArgument(VideoCodec codec) => _codec = codec;

        public VideoCodecArgument(VideoCodec codec, int bitrate, bool includeYUV = true)
        {
            _codec = codec;
            _bitrate = bitrate;
            _includeYUV = includeYUV;
        }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            var video = $"-c:v {_codec.ToString().ToLower()}";

            if (_includeYUV)
            {
                video += " -pix_fmt yuv420p";
            }

            if (_bitrate != default)
            {
                video += $" -b:v {_bitrate}k";
            }

            return video;
        }
    }
}
