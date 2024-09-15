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
            "3F-AE-AF-C2-8D-3C-31-E6-D7-BF-62-8A-53-43-8E-7D-24-A8-68-16-F1-5D-10-F6-BA-54-E1-8F-8F-EC-26-C2";
        var path = Path.GetTempFileName();
        var input = "foo";

        // Act
        var result = Program.SaveText(path, input.ToArray());

        // Assert
        Assert.Equal(expected, BitConverter.ToString(result));
        Assert.True(File.Exists(path));

        // Cleanup
        File.Delete(path);
    }
}
