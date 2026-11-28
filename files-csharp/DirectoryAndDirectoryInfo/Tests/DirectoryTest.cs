using DirectoryAndDirectoryInfo;

namespace Tests
{
    public class DirectoryMethodsTests : IDisposable
    {
        private readonly string _testDirectoryPath =
            Path.Combine(Path.GetTempPath(), "CM-Demos-Tests", Guid.NewGuid().ToString());

        public DirectoryMethodsTests()
        {
            Directory.CreateDirectory(_testDirectoryPath);
        }

        [Fact]
        public void WhenCreateADirectoryIsCalled_ShouldReturnDirectoryInfo()
        {
            var path = Path.Combine(_testDirectoryPath, "test_directory");

            DirectoryInfo result = DirectoryMethods.CreateADirectory(path);

            Assert.True(result.Exists);
            Assert.True(Directory.Exists(path));
        }

        [Fact]
        public void GivenExistingDirectory_WhenCreateADirectoryIsCalledAgain_ThenItReturnsTheSameDirectoryAndKeepsItsFiles()
        {
            var path = Path.Combine(_testDirectoryPath, "existing");
            DirectoryMethods.CreateADirectory(path);
            File.WriteAllText(Path.Combine(path, "notes.txt"), "Keep me");

            DirectoryInfo result = DirectoryMethods.CreateADirectory(path);

            Assert.True(result.Exists);
            Assert.Single(Directory.GetFiles(path));
        }

        [Fact]
        public void GivenNonEmptyDirectory_WhenDeleteEmptyDirectoryIsCalled_ThenIOExceptionIsThrown()
        {
            File.WriteAllText(Path.Combine(_testDirectoryPath, "notes.txt"), "Keep me");

            Assert.Throws<IOException>(() => DirectoryMethods.DeleteEmptyDirectory(_testDirectoryPath));
            Assert.True(Directory.Exists(_testDirectoryPath));
        }

        [Fact]
        public void WhenDeleteDirectoryIsCalled_ShouldDeleteDirectoryAndItsContents()
        {
            Directory.CreateDirectory(Path.Combine(_testDirectoryPath, "SubFolder"));
            File.WriteAllText(Path.Combine(_testDirectoryPath, "notes.txt"), "Delete me");

            DirectoryMethods.DeleteDirectory(_testDirectoryPath);

            Assert.False(Directory.Exists(_testDirectoryPath));
        }

        [Fact]
        public void WhenGetFilesAndGetDirectoriesAreCalled_ShouldReturnFullPaths()
        {
            var filePath = Path.Combine(_testDirectoryPath, "notes.txt");
            var subDirectoryPath = Path.Combine(_testDirectoryPath, "SubFolder");
            File.WriteAllText(filePath, "x");
            Directory.CreateDirectory(subDirectoryPath);

            Assert.Equal([filePath], DirectoryMethods.GetFilesInDirectory(_testDirectoryPath));
            Assert.Equal([subDirectoryPath], DirectoryMethods.GetDirectories(_testDirectoryPath));
        }

        public void Dispose()
        {
            if (Directory.Exists(_testDirectoryPath))
            {
                Directory.Delete(_testDirectoryPath, true);
            }
        }
    }
}
