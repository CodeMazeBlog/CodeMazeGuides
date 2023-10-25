using FileAlreadyInUseException;
using Xunit;

namespace FileAlreadyInUseExceptionTests;

public class ProgramTests
{
    [Fact]
    public void WhenFileNotInUse_AndIsFileInUseGeneric_ThenReturnsFalse()
    {
        // Arrange
        var filePath = "testFile0.txt";
        using (File.Create(filePath)) ;

        // Act
        bool result = Program.IsFileInUseGeneric(new FileInfo(filePath));

        // Assert
        Assert.False(result);
        File.Delete(filePath); 
    }

    [Fact]
    public void WhenFileInUse_AndIsFileInUseGeneric_ThenReturnsTrue()
    {
        // Arrange
        var filePath = "testFile1.txt";
        FileStream fileStream = File.Create(filePath);

        // Act
        bool result = Program.IsFileInUseGeneric(new FileInfo(filePath));

        // Assert
        Assert.True(result);
        fileStream.Close();
        File.Delete(filePath);
    }

    [Fact]
    public void WhenFileNotInUse__AndIsFileInUse_ThenReturnsFalse()
    {
        // Arrange
        var filePath = "testFile2.txt";
        using (File.Create(filePath)) ;

        // Act
        bool result = Program.IsFileInUse(new FileInfo(filePath));

        // Assert
        Assert.False(result);
        File.Delete(filePath); 
    }

    [Fact]
    public void WhenFileInUse_AndIsFileInUse_ThenReturnsTrue()
    {
        // Arrange
        var filePath = "testFile3.txt";
        FileStream fileStream = File.Create(filePath);

        // Act
        bool result = Program.IsFileInUse(new FileInfo(filePath));

        // Assert
        Assert.True(result);
        fileStream.Close();
        File.Delete(filePath);
    }
}