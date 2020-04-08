using f14.xunit;
using FFMpeg.Probe;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FFMpeg.Tests
{
    public class ProbeTest : XUnitTestBase
    {
        private const string FFProbePath = "C:/ffmpeg-static-x64/bin/ffprobe.exe";
        private const string Res_Video_with_Audio = "Resources/input.mp4";
        private const string Res_Video_Only = "Resources/mute.mp4";
        private const string Res_Audio_Only = "Resources/audio_only.mp4";
        private const string Res_Audio = "Resources/audio.mp3";
        private const string Res_Empty = "Resources/empty.txt.mp4";
        private readonly IProbe _probe;

        public ProbeTest(ITestOutputHelper logger) : base(logger)
        {
            _probe = new FFProbe(FFProbePath);
        }

        [Fact]
        public async Task GetMetatData_Video_and_Audio_Streams()
        {
            var metadata = await _probe.GetMetadataAsync(new FileInfo(Res_Video_with_Audio));

            Assert.NotEmpty(metadata.VideoStreams);
            Assert.NotEmpty(metadata.AudioStreams);

            Logger.WriteLine(metadata.ToString());
        }

        [Fact]
        public async Task GetMetatData_Video_Only_Stream()
        {
            var metadata = await _probe.GetMetadataAsync(new FileInfo(Res_Video_Only));

            Assert.NotEmpty(metadata.VideoStreams);
            Assert.Empty(metadata.AudioStreams);

            Logger.WriteLine(metadata.ToString());
        }

        [Fact]
        public async Task GetMetatData_Audio_Only_Stream()
        {
            var metadata = await _probe.GetMetadataAsync(new FileInfo(Res_Audio_Only));

            Assert.Empty(metadata.VideoStreams);
            Assert.NotEmpty(metadata.AudioStreams);

            Logger.WriteLine(metadata.ToString());
        }

        [Fact]
        public async Task GetMetatData_Audio_Stream()
        {
            var metadata = await _probe.GetMetadataAsync(new FileInfo(Res_Audio));

            Assert.Empty(metadata.VideoStreams);
            Assert.NotEmpty(metadata.AudioStreams);

            Logger.WriteLine(metadata.ToString());
        }

        [Fact]
        public async Task GetMetatData_Empty()
        {           
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _probe.GetMetadataAsync(new FileInfo(Res_Empty)));            
        }
    }
}
