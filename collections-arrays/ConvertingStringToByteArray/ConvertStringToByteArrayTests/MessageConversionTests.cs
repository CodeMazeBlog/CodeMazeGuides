namespace ConvertStringToByteArrayTests;

public class MessageConversionTests
{
    private const string _message = "Welcome to CodeMaze!";
    private static readonly byte[] _expectedByteArray
        = new byte[] { 87, 101, 108, 99, 111, 109, 101, 32, 116, 111, 32, 67, 111, 100, 101, 77, 97, 122, 101, 33 };

    [Fact]
    public void WhenConvertingToUTF8Bytes_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToUTF8Bytes(_message);

        // Assert
        Assert.Equal(_expectedByteArray, result);
    }

    [Fact]
    public void WhenConvertingToByteArrayUsingCasting_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingCasting(_message);

        // Assert
        Assert.Equal(_expectedByteArray, result);
    }

    [Fact]
    public void WhenConvertingToByteArrayUsingConvertToByte_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingConvertToByte(_message);

        // Assert
        Assert.Equal(_expectedByteArray, result);
    }

    [Fact]
    public void WhenConvertingToByteArrayUsingEncoding_ThenReturnByteArray()
    {
        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingEncoding(_message);

        // Assert
        Assert.Equal(_expectedByteArray, result);
    }
}