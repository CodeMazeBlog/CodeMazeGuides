using ConvertingStringToByteArray;
using System.Text;

namespace ConvertStringToByteArrayTests;

public class MessageConversionTests
{
    private string _message = "Welcome to CodeMaze!";

    [Fact]
    public void GivenString_WhenConvertingToUTF8Bytes_ThenReturnByteArray()
    {
        // Arrange
        var expectedByteArray = Encoding.UTF8.GetBytes(_message);

        // Act
        var result = MessageConversion.ConvertStringToUTF8Bytes(_message);

        // Assert
        Assert.Equal(expectedByteArray, result);
    }

    [Fact]
    public void GivenString_WhenConvertingToByteArrayUsingCasting_ThenReturnByteArray()
    {
        // Arrange
        var expectedByteArray = new byte[_message.Length];

        for (int i = 0; i < _message.Length; i++)
        {
            expectedByteArray[i] = (byte)_message[i];
        }

        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingCasting(_message);

        // Assert
        Assert.Equal(expectedByteArray, result);
    }

    [Fact]
    public void GivenString_WhenConvertingToByteArrayUsingConvertToByte_ThenReturnByteArray()
    {
        // Arrange
        var expectedByteArray = new byte[_message.Length];

        for (int i = 0; i < _message.Length; i++)
        {
            expectedByteArray[i] = Convert.ToByte(_message[i]);
        }

        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingConvertToByte(_message);

        // Assert
        Assert.Equal(expectedByteArray, result);
    }

    [Fact]
    public void GivenStringAndEncodingISO88591_WhenConvertingToByteArrayUsingEncoding_ThenReturnByteArray()
    {
        // Arrange
        var encoding = Encoding.GetEncoding("ISO-8859-1");

        var expectedByteArray = new byte[encoding.GetByteCount(_message)];
        encoding.GetBytes(_message, expectedByteArray);

        // Act
        var result = MessageConversion.ConvertStringToByteArrayUsingEncoding(_message);

        // Assert
        Assert.Equal(expectedByteArray, result);
    }
}