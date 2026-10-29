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
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var tempFile =  Path.Combine(appDataPath, "text.txt");

        //Act
        TempFileCreator.CreateTempFile(tempFile);
        var tempFileContent = File.ReadAllText(tempFile);

        File.Delete(tempFile);

        //Assert
        Assert.Equal("Hello from CodeMaze!", tempFileContent);
    }

    [Fact]
    public void GivenTempSubdirectory_WhenSaving_TheContentIsAsExpected()
    {
        //Arrange
        var tempDirectory = Directory.CreateTempSubdirectory("codemaze-");
        var tempFile = Path.Combine(tempDirectory.FullName, "text.txt");

        //Act
        TempFileCreator.CreateTempFile(tempFile);
        var tempFileContent = File.ReadAllText(tempFile);

        tempDirectory.Delete(recursive: true);

        //Assert
        Assert.Equal("Hello from CodeMaze!", tempFileContent);
        Assert.False(Directory.Exists(tempDirectory.FullName));
    }

    [Fact]
    public void GivenDeleteOnClose_WhenStreamIsDisposed_TheFileIsGone()
    {
        //Arrange
        var tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var options = new FileStreamOptions
        {
            Mode = FileMode.CreateNew,
            Access = FileAccess.ReadWrite,
            Options = FileOptions.DeleteOnClose
        };

        //Act
        bool existedWhileOpen;
        using (var stream = new FileStream(tempFile, options))
        {
            stream.Write("Hello from CodeMaze!"u8);
            existedWhileOpen = File.Exists(tempFile);
        }

        //Assert
        Assert.True(existedWhileOpen);
        Assert.False(File.Exists(tempFile));
    }
}
