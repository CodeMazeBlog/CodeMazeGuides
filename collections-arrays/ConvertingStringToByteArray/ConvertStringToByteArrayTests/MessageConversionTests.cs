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
}