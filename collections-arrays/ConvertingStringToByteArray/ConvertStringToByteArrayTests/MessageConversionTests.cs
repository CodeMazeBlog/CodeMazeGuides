namespace ConvertStringToByteArrayTests;

public class MessageConversionTests
{
    private const string Message = "Welcome to CodeMaze!";
    private static readonly byte[] ExpectedByteArray
        = new byte[] { 87, 101, 108, 99, 111, 109, 101, 32, 116, 111, 32, 67, 111, 100, 101, 77, 97, 122, 101, 33 };

    [Fact]
    public void WhenConvertingToUTF8Bytes_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToUTF8Bytes(Message);

        // Assert
        Assert.Equal(ExpectedByteArray, result);
    }

    [Fact]
    public void WhenConvertingToByteArrayUsingCasting_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingCasting(Message);

        // Assert
        Assert.Equal(ExpectedByteArray, result);
    }

    [Fact]
    public void WhenConvertingToByteArrayUsingConvertToByte_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingConvertToByte(Message);

        // Assert
        Assert.Equal(ExpectedByteArray, result);
    }

    [Fact]
    public void WhenConvertingToByteArrayUsingEncoding_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingEncoding(Message);

        // Assert
        Assert.Equal(ExpectedByteArray, result);
    }

    [Fact]
    public void WhenRoundTrippingThroughUTF8_ThenReturnOriginalString()
    {
        // Arrange
        const string original = "café 😀";

        // Act
        var result = MessageConversion.ConvertUTF8BytesToString(
            MessageConversion.ConvertStringToUTF8Bytes(original));

        // Assert
        Assert.Equal(original, result);
    }

    [Fact]
    public void WhenRoundTrippingThroughASCII_ThenUnrepresentableCharactersBecomeQuestionMarks()
    {
        // Arrange
        const string original = "café 😀";

        // Act
        var result = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(original));

        // Assert
        Assert.Equal("caf? ??", result);
    }

    [Fact]
    public void WhenDecodingInvalidUTF8Bytes_ThenReturnReplacementCharacter()
    {
        // Act
        var result = MessageConversion.ConvertUTF8BytesToString([0xFF]);

        // Assert
        Assert.Equal("�", result);
    }

    [Fact]
    public void WhenCastingCharacterAboveLatin1Range_ThenTruncateSilently()
    {
        // Arrange
        var character = 'Ā';

        // Act
        var result = (byte)character;

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenConvertingCharacterAboveLatin1Range_ThenThrowOverflowException()
    {
        // Arrange
        var character = 'Ā';

        // Act
        var exception = Assert.Throws<OverflowException>(() => Convert.ToByte(character));

        // Assert
        Assert.Equal("Value was either too large or too small for an unsigned byte.", exception.Message);
    }

    // Encoding.RegisterProvider is process-global and cannot be undone, so the
    // before and after assertions have to live in one test to stay deterministic.
    [Fact]
    public void WhenRegisteringCodePagesProvider_ThenGetEncodingResolvesWindows1252()
    {
        // Assert: the two overloads fail differently before registration
        Assert.Throws<NotSupportedException>(() => Encoding.GetEncoding(1252));
        Assert.Throws<ArgumentException>(() => Encoding.GetEncoding("windows-1252"));

        // Act
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Assert
        var encoding = Encoding.GetEncoding(1252);
        Assert.Equal(1252, encoding.CodePage);
        Assert.Equal("windows-1252", encoding.WebName);
        Assert.Equal(1252, Encoding.GetEncoding("windows-1252").CodePage);
    }
}