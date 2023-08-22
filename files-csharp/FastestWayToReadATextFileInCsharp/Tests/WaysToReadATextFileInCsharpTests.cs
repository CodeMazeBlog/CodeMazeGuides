namespace Tests;

public class WaysToReadATextFileInCsharpTests
{
    private readonly WaysToReadATextFileInCsharp _textFileReader;

    private const string ExpectedText
        = """
            Integer facilisis ex libero, ut suscipit leo blandit non. Vivamus nec ipsum orci.
            Proin nec mauris dui. Proin at felis et eros commodo aliquet.
            Pellentesque lacinia porta leo, non accumsan turpis sagittis et.
            Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere.
            """;
    
    private static readonly string _tempFilePath = Path.GetTempFileName();

    public WaysToReadATextFileInCsharpTests()
    {
        File.WriteAllText(_tempFilePath, ExpectedText);
        _textFileReader = new WaysToReadATextFileInCsharp(_tempFilePath);
    }

    [Fact]
    public void WhenReadingATextFileWithFileReadAllLines_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseFileReadAllLines();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithFileReadAllText_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseFileReadAllText();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithFileReadLines_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseFileReadLines();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithStreamReaderReadLine_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseStreamReaderReadLine();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithStreamReaderReadToEnd_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseStreamReaderReadToEnd();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithStreamReaderReadBlock_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseStreamReaderReadBlock();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithStreamReaderReadBlockWithSpan_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseStreamReaderReadBlockWithSpan();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithBufferedStreamObject_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseBufferedStreamObject();

        Assert.Equal(ExpectedText, result);
    }

    [Fact]
    public void WhenReadingATextFileWithBufferedStreamObjectWithFileStreamBufferDisabled_ThenReturnsExpectedText()
    {
        var result = _textFileReader.UseBufferedStreamObjectWithNoFileStreamBuffer();

        Assert.Equal(ExpectedText, result);
    }
}