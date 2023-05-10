using HowToConvertAStreamToAByteArray;

namespace Tests
{
    public class ConvertMethodsTest
    {
        private static readonly string _sampleFilePath
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "samplefile.txt");

        private readonly FileStream _stream
            = new(_sampleFilePath, FileMode.Open, FileAccess.Read);

        private readonly byte[] _expected = File.ReadAllBytes(_sampleFilePath);

        [Fact]
        public void GivenAStream_WhenConvertingWithMemoryStream_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_stream);
            var result = converter.UseMemoryStream();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithBinaryReader_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_stream);
            var result = converter.UseBinaryReader();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithBufferedStream_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_stream);
            var result = converter.UseBufferedStream();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithStreamDotReadMethod_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_stream);
            var result = converter.UseStreamDotReadMethod();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithAStreamReader_ThenReturnsAByteArray()
        {
            var converter = new ConvertStreamToByteArray(_stream);
            var result = converter.UseStreamReader();

            Assert.Equal(_expected, result);
        }
    }
}