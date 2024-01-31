namespace CountFilesInaFolderTests;

public class FileCounterUnitTests : IDisposable
{
    private readonly string _tempDirectory;
    private readonly int _expectedFileCount = 1000;

    public FileCounterUnitTests()
    {
        _tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_tempDirectory);

        for (var i = 0; i < 1000; i++)
        {
            File.Create(Path.Combine(_tempDirectory, $"file{i}.txt")).Dispose();
        }
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingGetFiles_ThenReturnCorrectFileCount()
    {
        // Act
        var actualFileCount = FileCounterUsingGetFiles.CountFilesUsingGetFiles(_tempDirectory);

        // Assert
        Assert.Equal(_expectedFileCount, actualFileCount);
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingLINQEnumerateFiles_ThenReturnCorrectFileCount()
    {
        // Act
        var actualFileCount = FileCounterUsingLINQ.CountFilesUsingLINQEnumerateFiles(_tempDirectory);

        // Assert
        Assert.Equal(_expectedFileCount, actualFileCount);
    }

    /*[Fact]
    public void GivenDirectoryWithFiles_WhenUsingWinAPI_ThenReturnCorrectFileCount()
    {
        var actualFileCount = FileCounterUsingWinAPI.CountFilesUsingWinAPI(TempDirectory);

        Assert.Equal(ExpectedFileCount, actualFileCount);
    }*/

    public void Dispose()
    {
        Directory.Delete(_tempDirectory, true);
    }
}