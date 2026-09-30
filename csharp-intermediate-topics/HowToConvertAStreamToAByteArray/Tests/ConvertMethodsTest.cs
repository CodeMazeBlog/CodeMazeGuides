using HowToConvertAStreamToAByteArray;

namespace Tests
{
    public class ConvertMethodsTest
    {
        private static readonly string _sampleFilePath
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "samplefile.txt");

        private readonly FileStream _stream;
        private readonly ConvertStreamToByteArray _converter;

        private readonly byte[] _expected = File.ReadAllBytes(_sampleFilePath);

        public ConvertMethodsTest()
        {
            _stream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            _converter = new ConvertStreamToByteArray();
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithMemoryStream_ThenReturnsAByteArray()
        {
            var result = _converter.UseMemoryStream(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithBinaryReader_ThenReturnsAByteArray()
        {
            var result = _converter.UseBinaryReader(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithBufferedStream_ThenReturnsAByteArray()
        {
            var result = _converter.UseBufferedStream(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithStreamReadMethod_ThenReturnsAByteArray()
        {
            var result = _converter.UseStreamDotReadMethod(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithStreamReader_ThenReturnsAByteArray()
        {
            var result = _converter.UseStreamReader(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithReadExactly_ThenReturnsAByteArray()
        {
            var result = _converter.UseReadExactly(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAStream_WhenConvertingWithCopyTo_ThenReturnsAByteArray()
        {
            var result = _converter.UseCopyTo(_stream);

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void GivenAByteArray_WhenWrappingInAMemoryStreamConstructor_ThenStreamReadsBackTheSameBytes()
        {
            var result = _converter.UseMemoryStreamConstructor(_expected);

            Assert.Equal(_expected.Length, result.Length);
            Assert.Equal(_expected, ReadToEnd(result));
        }

        [Fact]
        public void GivenAByteArray_WhenWritingToAnExpandableMemoryStream_ThenStreamReadsBackTheSameBytes()
        {
            var result = _converter.UseWritableMemoryStream(_expected);

            Assert.Equal(_expected.Length, result.Length);
            Assert.Equal(_expected, ReadToEnd(result));
        }

        private static byte[] ReadToEnd(Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }
    }
}