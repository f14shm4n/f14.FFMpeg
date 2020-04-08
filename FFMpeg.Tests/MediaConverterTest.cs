using f14.xunit;
using FFMpeg.Arguments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FFMpeg.Tests
{
    public class MediaConverterTest : XUnitTestBase
    {
        private const string FFMpegPath = "C:/ffmpeg-static-x64/bin/ffmpeg.exe";
        private const string Res_wav = "Resources/sample.wav";
        private const string Res_wma = "Resources/sample.wma";
        private const string Res_mov = "Resources/sample.mov";

        private readonly IFFMpeg _ffmpeg;

        public MediaConverterTest(ITestOutputHelper logger) : base(logger)
        {
            _ffmpeg = new FFMpegWrapper(FFMpegPath);
        }

        [Fact]
        public async Task Execute_Convert_wav_to_mp3()
        {
            const string OutputFilePath = "test_wav_to_mp3.mp3";

            File.Delete(OutputFilePath);

            var argBuilder = new ArgumentBuilder();
            argBuilder
                .AddInput(new FileInfo(Res_wav))
                .AddOutput(new FileInfo(OutputFilePath))
                .AddAudioCodec(AudioCodec.Aac, AudioQuality.Normal);

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
        }

        [Fact]
        public async Task Execute_Convert_wma_to_mp3()
        {
            const string OutputFilePath = "test_wma_to_mp3.mp3";

            File.Delete(OutputFilePath);

            var argBuilder = new ArgumentBuilder();
            argBuilder
                .AddInput(new FileInfo(Res_wma))
                .AddOutput(new FileInfo(OutputFilePath))
                .AddAudioCodec(AudioCodec.Aac, AudioQuality.Normal);

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
        }

        [Fact]
        public async Task Execute_Convert_mov_to_mp4()
        {
            const string OutputFilePath = "test_mov_to_mp4.mp4";

            File.Delete(OutputFilePath);

            var argBuilder = new ArgumentBuilder();
            argBuilder
                .AddInput(new FileInfo(Res_mov))
                .AddOutput(new FileInfo(OutputFilePath))
                .AddVideoCodec(VideoCodec.LibX264);

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
        }
    }
}
