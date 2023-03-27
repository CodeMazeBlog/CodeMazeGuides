using HowToConvertAStreamToAByteArray;

namespace Tests
{
    public class ConvertMethodsTest
    {
        private static readonly string _sampleFilePath
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "samplefile.txt");

        private readonly FileStream _sampleStream
            = new(_sampleFilePath, FileMode.Open, FileAccess.Read);

        private readonly byte[] _expected = File.ReadAllBytes(_sampleFilePath);

        [Fact]
        public void GivenAStream_WhenConvertingWithAMemoryStream_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_sampleStream);
            var result = converter.UseAMemoryStream();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithABinaryReader_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_sampleStream);
            var result = converter.UseABinaryReader();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithABufferedStream_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_sampleStream);
            var result = converter.UseABufferedStream();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithTheStreamReadMethod_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_sampleStream);
            var result = converter.UseTheStreamDotReadMethod();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithAStreamReader_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_sampleStream);
            var result = converter.UseAStreamReader();

            Assert.Equal(_expected, result);
        }
    }
}