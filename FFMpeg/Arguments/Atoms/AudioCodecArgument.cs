namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents parameter of audio codec and it's quality
    /// </summary>
    public class AudioCodecArgument : IArgument
    {
        private readonly AudioCodec _codec;
        private readonly int _bitrate = AudioQuality.Normal;

        public AudioCodecArgument(AudioCodec codec) => _codec = codec;

        public AudioCodecArgument(AudioCodec codec, int bitrate)
        {
            _codec = codec;
            _bitrate = bitrate;
        }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            return $"-c:a {_codec.ToString().ToLower()} -b:a {_bitrate}k";
        }
    }
}
