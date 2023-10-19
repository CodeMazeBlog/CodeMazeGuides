using DirectoryAndDirectoryInfo;

namespace Tests
{
    public class DirectoryMethodsTests
    {
        private readonly string _testDirectoryPath = @"C:\Public\CM-Demos\Test";

        public DirectoryMethodsTests()
        {
            Directory.CreateDirectory(_testDirectoryPath);
        }

        [Fact]
        public void WhenCreateADirectoryIsCallled_ShouldReturnDirectoryInfo()
        {
            // Arrange
            var path = Path.Combine(_testDirectoryPath, "test_directory");

            // Act
            DirectoryInfo? result = DirectoryMethods.CreateADirectory(path);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenDeleteDirectoryIsCalled_ShouldDeletesDirectory()
        {
            // Act
            DirectoryMethods.DeleteDirectory(_testDirectoryPath);

            // Assert
            Assert.False(Directory.Exists(_testDirectoryPath));
        }

        public void Dispose()
        {
            // Clean up the test directory after tests
            if (Directory.Exists(_testDirectoryPath))
            {
                Directory.Delete(_testDirectoryPath, true);
            }
        }

    }
}

