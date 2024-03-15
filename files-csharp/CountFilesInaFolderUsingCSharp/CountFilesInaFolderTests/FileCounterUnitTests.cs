namespace CountFilesInaFolderTests;

public class FileCounterUnitTests : IClassFixture<FileCounterFixture>
{
    FileCounterFixture _fixture { get; set; }
    private readonly int _expectedFileCount = 1000;

    public FileCounterUnitTests(FileCounterFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingGetFiles_ThenReturnCorrectFileCount()
    {
        // Act
        var actualFileCount = FileCounterUsingGetFiles.CountFilesUsingGetFiles(_fixture.TempDirectory);

        // Assert
        Assert.Equal(_expectedFileCount, actualFileCount);
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingLINQEnumerateFiles_ThenReturnCorrectFileCount()
    {
        // Act
        var actualFileCount = FileCounterUsingLINQ.CountFilesUsingLINQEnumerateFiles(_fixture.TempDirectory);

        // Assert
        Assert.Equal(_expectedFileCount, actualFileCount);
    }

    [Fact]
    public void GivenDirectoryWithFiles_WhenUsingWinAPI_ThenReturnCorrectFileCount()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Act
            var actualFileCount = FileCounterUsingWinAPI.CountFilesUsingWinAPI(_fixture.TempDirectory);

            // Assert
            Assert.Equal(_expectedFileCount, actualFileCount);
        }
    }
}