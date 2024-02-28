namespace HowToConvertReadOnlyMemoryToByteArrayInCSharpUnitTests;

public class ProgramTests
{
    [Fact]
    public void GivenReadOnlyMemoryToByteArray_WhenInputIsValidIntArray123_ThenReturnsByteArray()
    {
        // Arrange
        var expected = "01-00-00-00-02-00-00-00-03-00-00-00";
        var input = new[] { 1, 2, 3 };

        // Act
        var result = Program.ReadOnlyMemoryToByteArray<int>(input);

        // Assert
        Assert.Equal(expected, BitConverter.ToString(result));
    }

    [Fact]
    public void GivenReadOnlyMemoryToByteArray_WhenInputIsValidStringFoo_ThenReturnsByteArray()
    {
        // Arrange
        var expected = "66-00-6F-00-6F-00";
        var input = "foo";

        // Act
        var result = Program.ReadOnlyMemoryToByteArray<char>(input.ToArray());

        // Assert
        Assert.Equal(expected, BitConverter.ToString(result));
    }

    [Fact]
    public void GivenSavePassword_WhenInputIsValidStringPassword_ThenSaveFileAndReturnsHash()
    {
        // Arrange
        var expected =
            "E2-01-06-5D-05-54-65-26-15-C3-20-C0-0A-1D-5B-C8-ED-CA-46-9D-72-C2-79-0E-24-15-2D-0C-1E-2B-61-89";
        var path = Path.GetTempFileName();
        var input = "password";

        // Act
        var result = Program.SavePassword(path, input.ToArray());

        // Assert
        Assert.Equal(expected, BitConverter.ToString(result));
        Assert.True(File.Exists(path));

        // Cleanup
        File.Delete(path);
    }
}
