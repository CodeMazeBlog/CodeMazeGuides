namespace WriteFileToTempFolder.Test;

public class TempFileCreatorTests
{
    [Fact]
    public void GivenCustomFileName_WhenSaving_TheContentIsAsExpected()
    {
        //Arrange
        const string customTempFileName = "file.txt";
        var tempFile = Path.Combine(Path.GetTempPath(), customTempFileName);

        //Act
        TempFileCreator.CreateTempFile(tempFile);
        var tempFileContent = File.ReadAllText(tempFile);

        File.Delete(tempFile);

        //Assert
        Assert.Equal("Hello from CodeMaze!", tempFileContent);
    }

    [Fact]
    public void GivenSystemCreatedFileName_WhenSaving_TheContentIsAsExpected()
    {
        //Arrange
        var tempFile = System.IO.Path.GetTempFileName();

        //Act
        TempFileCreator.CreateTempFile(tempFile);
        var tempFileContent = File.ReadAllText(tempFile);

        File.Delete(tempFile);

        //Assert
        Assert.Equal("Hello from CodeMaze!", tempFileContent);
    }

    [Fact]
    public void GivenSystemSpecialFolderAndCustomName_WhenSaving_TheContentIsAsExpected()
    {
        //Arrange
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var tempFile =  Path.Combine(appDataPath, "text.txt");

        //Act
        TempFileCreator.CreateTempFile(tempFile);
        var tempFileContent = File.ReadAllText(tempFile);

        File.Delete(tempFile);

        //Assert
        Assert.Equal("Hello from CodeMaze!", tempFileContent);
    }
}