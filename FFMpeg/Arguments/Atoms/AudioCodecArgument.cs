namespace FFMpeg.Arguments.Atoms
{
    /// <summary>
    /// Represents parameter of audio codec and it's quality
    /// </summary>
    public class AudioCodecArgument : IArgument
    {
        private readonly string? _codec;
        private readonly int? _bitrate;

        /// <summary>
        /// Creates new audio codec argument.
        /// </summary>
        /// <param name="codec">Audio codec.</param>
        public AudioCodecArgument(string codec) => _codec = codec;
        /// <summary>
        /// Creates new audio codec argument.
        /// </summary>
        /// <param name="bitrate">Audio bitrate in kBit/s</param>
        public AudioCodecArgument(int bitrate) => _bitrate = bitrate;
        /// <summary>
        /// Creates new audio codec argument.
        /// </summary>
        /// <param name="codec">Audio codec.</param>
        /// <param name="bitrate">Audio bitrate in kBit/s</param>
        public AudioCodecArgument(string codec, int bitrate)
        {
            _codec = codec;
            _bitrate = bitrate;
        }

        /// <inheritdoc/>
        public string GetStringValue()
        {
            var arguments = string.Empty;

            if (!string.IsNullOrWhiteSpace(_codec))
            {
                arguments += $"-c:a {_codec}";
            }
            if (_bitrate.HasValue)
            {
                if (arguments.Length > 0)
                {
                    arguments += " ";
                }
                arguments += $"-b:a {_bitrate}k";
            }
            return arguments;
        }
    }
}
