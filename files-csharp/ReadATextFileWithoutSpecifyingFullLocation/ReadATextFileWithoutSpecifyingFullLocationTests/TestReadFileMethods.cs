namespace ReadATextFileWithoutSpecifyingFullLocationTests;

public class TestReadFileMethods
{
    private const string ExpectedContent =
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

    [Fact]
    public void When_ValidFileNameIsProvidedInAppDomainBaseDirectory_Then_FileContentIsReturned()
    {
        // Arrange
        var fileName = Path.GetRandomFileName();
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(baseDirectory, fileName);
        using var tempFile = TempFile.CreateTempFile(filePath, ExpectedContent);

        // Act
        var fileContent = ReadFileMethods.ReadFileUsingBaseDirectory(fileName);

        // Assert
        Assert.Equal(ExpectedContent, fileContent);
    }

    [Fact]
    public void When_ValidFileNameIsProvidedWithOnlyFileName_Then_FileContentIsReturned()
    {
        // Arrange
        var fileName = Path.GetRandomFileName();
        var directory = Directory.GetCurrentDirectory();
        var filePath = Path.Combine(directory, fileName);
        using var tempFile = TempFile.CreateTempFile(filePath, ExpectedContent);

        // Act
        var fileContent = ReadFileMethods.ReadFile(fileName);

        // Assert
        Assert.Equal(ExpectedContent, fileContent);
    }

    [Fact]
    public void When_ValidFileNameIsProvidedInCurrentDirectory_Then_FileContentIsReturned()
    {
        // Arrange
        var fileName = Path.GetRandomFileName();
        var directory = Directory.GetCurrentDirectory();
        var filePath = Path.Combine(directory, fileName);
        using var tempFile = TempFile.CreateTempFile(filePath, ExpectedContent);

        // Act
        var fileContent = ReadFileMethods.ReadFileUsingCurrentDirectory(fileName);

        // Assert
        Assert.Equal(ExpectedContent, fileContent);
    }

    private class TempFile : IDisposable
    {
        private readonly string _fileName;

        private TempFile(string fileName, string fileContents)
        {
            _fileName = fileName;
            File.WriteAllText(_fileName, fileContents);
        }

        public static TempFile CreateTempFile(string fileName, string fileContents) => new(fileName, fileContents);

        public void Dispose()
        {
            try
            {
                File.Delete(_fileName);
            }
            catch { }
        }
    }
}