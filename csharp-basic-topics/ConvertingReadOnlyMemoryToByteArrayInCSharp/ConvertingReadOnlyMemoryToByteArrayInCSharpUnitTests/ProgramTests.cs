namespace ConvertingReadOnlyMemoryToByteArrayInCSharpUnitTests;

public class ProgramTests
{
    [Fact]
    public void GivenReadOnlyMemoryOfInt_WhenConvertedToByteArray_ThenReturnsByteArray()
    {
        // Arrange
        var expected = "AQAAAAIAAAADAAAA";

        // Act
        var result = Program.ReadOnlyMemoryOfIntToByteArray();

        // Assert
        Assert.Equal(expected, Convert.ToBase64String(result));
    }

    [Fact]
    public void GivenReadOnlyMemoryOfChar_WhenConvertedToByteArray_ThenReturnsByteArray()
    {
        // Arrange
        var expected = "ZgBvAG8A";

        // Act
        var result = Program.ReadOnlyMemoryOfCharToByteArray();

        // Assert
        Assert.Equal(expected, Convert.ToBase64String(result));
    }

    [Fact]
    public void GivenPassword_WhenHashed_ThenReturnsHash()
    {
        // Arrange
        var expected = "LCa0a2j/xo/5m0U8HTBBNBNCLXBkg7+g+YpeiGJm564=";

        // Act
        var result = Program.HashPassword("foo");

        // Assert
        Assert.Equal(expected, Convert.ToBase64String(result));
    }

    [Fact]
    public void GivenSavedToFile_WhenValidPathAndContent_ThenFileExists()
    {
        // Arrange
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var filePath = Path.Combine(documentsPath, "hello.txt");
        var content = "Hello, World!";

        // Act
        Program.SaveFile(filePath, content);

        // Assert
        Assert.True(File.Exists(filePath));

        // Cleanup
        File.Delete(filePath);
    }
}
