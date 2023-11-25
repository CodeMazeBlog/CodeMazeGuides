using FileAlreadyInUseException;
using Xunit;

namespace FileAlreadyInUseExceptionTests;

public class FileOperationsTests
{
    [Fact]
    public void WhenFileNotInUse_AndIsFileInUseGeneric_ThenReturnsFalse()
    {
        // Arrange
        var filePath = "testFile0.txt";
        using (File.Create(filePath));

        // Act
        var result = FileOperations.IsFileInUseGeneric(new FileInfo(filePath));

        // Assert
        File.Delete(filePath);
        Assert.False(result);
    }

    [Fact]
    public void WhenFileInUse_AndIsFileInUseGeneric_ThenReturnsTrue()
    {
        // Arrange
        var filePath = "testFile1.txt";
        var fileStream = File.Create(filePath);

        // Act
        var result = FileOperations.IsFileInUseGeneric(new FileInfo(filePath));

        // Assert
        fileStream.Close();
        File.Delete(filePath);
        Assert.True(result);
    }

    [Fact]
    public void WhenFileNotInUse__AndIsFileInUse_ThenReturnsFalse()
    {
        // Arrange
        var filePath = "testFile2.txt";
        using (File.Create(filePath));

        // Act
        var result = FileOperations.IsFileInUse(new FileInfo(filePath));

        // Assert
        File.Delete(filePath);
        Assert.False(result);
    }
}