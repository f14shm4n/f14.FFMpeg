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
    public class FFMpegTest : XUnitTestBase
    {
        private const string FFMpegPath = "C:/ffmpeg-static-x64/bin/ffmpeg.exe";
        private const string Res_wav = "Resources/sample.wav";
        private const string Res_wma = "Resources/sample.wma";
        private const string Res_mov = "Resources/sample.mov";
        private const string Res_mp3 = "Resources/sample.mp3";
        private const string Res_mp4 = "Resources/sample.mp4";        

        private readonly IFFMpeg _ffmpeg;

        public FFMpegTest(ITestOutputHelper logger) : base(logger)
        {
            _ffmpeg = new FFMpegWrapper(FFMpegPath);
        }

        [Fact]
        public async Task Execute_Convert_mp3_to_mp3()
        {
            const string OutputFilePath = "test_mp3_to_mp3.mp3";

            File.Delete(OutputFilePath);

            var argBuilder = new ArgumentBuilder();
            argBuilder
                .AddInput(new FileInfo(Res_mp3))
                .AddOutput(new FileInfo(OutputFilePath))
                .AddAudioCodec(AudioCodecs.LibMp3Lame, AudioQuality.Normal);

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
        }    
        
        [Fact]
        public async Task Execute_Convert_Default_mp3_to_mp3()
        {
            const string OutputFilePath = "test_mp3_to_mp3.mp3";

            File.Delete(OutputFilePath);

            var argBuilder = new ArgumentBuilder();
            argBuilder
                .AddInput(new FileInfo(Res_mp3))
                .AddOutput(new FileInfo(OutputFilePath));

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
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
                .AddAudioCodec(AudioCodecs.LibMp3Lame, AudioQuality.Normal);

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
                .AddAudioCodec(AudioCodecs.LibMp3Lame, AudioQuality.Normal);

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
                .AddVideoCodec(VideoCodecs.LibX264);

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
        }    
        
        [Fact]
        public async Task Execute_Convert_mp4_to_mp4()
        {
            const string OutputFilePath = "test_mp4_to_mp4.mp4";

            File.Delete(OutputFilePath);

            var argBuilder = new ArgumentBuilder();
            argBuilder
                .AddInput(new FileInfo(Res_mp4))
                .AddOutput(new FileInfo(OutputFilePath))
                .AddVideoCodec(VideoCodecs.LibX264);

            var mi = await _ffmpeg.ExecuteAsync(argBuilder);
            var outputFile = new FileInfo(mi.DestinationPath);

            Assert.True(outputFile.Exists);
            Assert.True(outputFile.Length > 0);
        }
    }
}
