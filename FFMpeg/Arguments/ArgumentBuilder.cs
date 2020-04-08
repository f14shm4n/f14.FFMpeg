using FFMpeg.Arguments.Atoms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FFMpeg.Arguments
{
    /// <summary>
    /// Container of arguments represented parameters of FFMPEG process
    /// </summary>
    public class ArgumentBuilder : IArgumentBuilder
    {
        private readonly Dictionary<Type, IArgument> _args = new Dictionary<Type, IArgument>();

        #region Public

        public ArgumentBuilder AddInput(FileInfo fileInfo)
        {
            Add(new InputArgument(fileInfo));
            return this;
        }

        public ArgumentBuilder AddInput(Uri url)
        {
            Add(new InputArgument(url));
            return this;
        }

        public ArgumentBuilder AddOutput(FileInfo fileInfo)
        {
            Add(new OutputArgument(fileInfo));
            return this;
        }

        public ArgumentBuilder AddVideoCodec(VideoCodec codec)
        {
            return AddVideoCodec(codec, 0);
        }

        public ArgumentBuilder AddVideoCodec(VideoCodec codec, int bitrate, bool includeYUV = true)
        {
            Add(new VideoCodecArgument(codec, bitrate, includeYUV));
            return this;
        }

        public ArgumentBuilder AddAudioCodec(AudioCodec codec, int bitrate)
        {
            Add(new AudioCodecArgument(codec, bitrate));
            return this;
        }

        #endregion

        #region Interface

        public IArgumentBuilder Add(IArgument argument)
        {
            var type = argument.GetType();
            _args[type] = argument;
            return this;
        }

        public T? Get<T>() where T : class, IArgument
        {
            var type = typeof(T);
            if (_args.TryGetValue(type, out IArgument a))
            {
                return (T)a;
            }
            return default;
        }

        public string Build()
        {
            if (!HasInput)
            {
                throw new InvalidOperationException($"At least one input argument must be specified.");
            }
            if (!HasOutput)
            {
                throw new InvalidOperationException($"Output argument must be specified.");
            }
            return string.Join(" ", _args.Select(a => a.Value.GetStringValue()));
        }

        #endregion

        #region Private 

        private bool HasInput => _args.ContainsKey(typeof(InputArgument));

        private bool HasOutput => _args.ContainsKey(typeof(OutputArgument));

        #endregion
    }
}
