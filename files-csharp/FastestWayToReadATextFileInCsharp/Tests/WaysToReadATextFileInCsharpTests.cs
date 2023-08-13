using FastestWayToReadATextFileInCsharp;

namespace Tests
{
    public class WaysToReadATextFileInCsharpTests
    {
        private static readonly string _sampleFilePath
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "SampleTextFile.txt");

        private readonly WaysToReadATextFileInCsharp _textFileReader;

        public WaysToReadATextFileInCsharpTests()
        {
            _textFileReader = new WaysToReadATextFileInCsharp(_sampleFilePath);
        }

        private readonly string _expected
            = """
            Integer facilisis ex libero, ut suscipit leo blandit non. Vivamus nec ipsum orci.
            Proin nec mauris dui. Proin at felis et eros commodo aliquet.
            Pellentesque lacinia porta leo, non accumsan turpis sagittis et.
            Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere.
            """;

        [Fact]
        public void WhenReadingATextFileWithFileReadAllLines_ThenReturnsAString()
        {
            var result = _textFileReader.UseFileReadAllLines();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void WhenReadingATextFileWithFileReadAllText_ThenReturnsAString()
        {
            var result = _textFileReader.UseFileReadLines();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void WhenReadingATextFileWithFileReadLines_ThenReturnsAString()
        {
            var result = _textFileReader.UseFileReadAllText();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void WhenReadingATextFileWithStreamReaderReadLine_ThenReturnsAString()
        {
            var result = _textFileReader.UseStreamReaderReadLine();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void WhenReadingATextFileWithStreamReaderReadToEnd_ThenReturnsAString()
        {
            var result = _textFileReader.UseStreamReaderReadToEnd();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void WhenReadingATextFileWithStreamReaderReadBlock_ThenReturnsAString()
        {
            var result = _textFileReader.UseStreamReaderReadBlock();

            Assert.Equal(_expected, result);
        }

        [Fact]
        public void WhenReadingATextFileWithBufferedStreamObject_ThenReturnsAString()
        {
            var result = _textFileReader.UseBufferedStreamObject();

            Assert.Equal(_expected, result);
        }
    }
}