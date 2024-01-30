namespace CountFilesInaFolderTests;

public class FileCounterUnitTests : IDisposable
{
    private readonly string TempDirectory;
    private readonly int ExpectedFileCount = 1000;

    public FileCounterUnitTests()
    {
        TempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(TempDirectory);

        for (var i = 0; i < 1000; i++)
        {
            File.Create(Path.Combine(TempDirectory, $"file{i}.txt")).Dispose();
        }
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingGetFiles_ThenReturnCorrectFileCount()
    {
        // Act
        var actualFileCount = FileCounterUsingGetFiles.CountFilesUsingGetFiles(TempDirectory);

        // Assert
        Assert.Equal(ExpectedFileCount, actualFileCount);
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingLINQEnumerateFiles_ThenReturnCorrectFileCount()
    {
        // Act
        var actualFileCount = FileCounterUsingLINQ.CountFilesUsingLINQEnumerateFiles(TempDirectory);

        // Assert
        Assert.Equal(ExpectedFileCount, actualFileCount);
    }

    /*[Fact]
    public void GivenDirectoryWithFiles_WhenUsingWinAPI_ThenReturnCorrectFileCount()
    {
        var actualFileCount = FileCounterUsingWinAPI.CountFilesUsingWinAPI(TempDirectory);

        Assert.Equal(ExpectedFileCount, actualFileCount);
    }*/

    public void Dispose()
    {
        Directory.Delete(TempDirectory, true);
    }
}