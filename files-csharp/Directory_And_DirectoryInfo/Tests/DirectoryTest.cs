using Directory_And_DirectoryInfo;

namespace Tests
{
    public class DirectoryMethodsTests
    {
        private readonly string testDirectoryPath = @"C:\Public\CM-Demos\Test";

        public DirectoryMethodsTests()
        {
            Directory.CreateDirectory(testDirectoryPath);
        }

        [Fact]
        public void WhenCreateADirectoryIsCallled_ShouldReturnDirectoryInfo()
        {
            // Arrange
            var path = Path.Combine(testDirectoryPath, "test_directory");

            // Act
            DirectoryInfo? result = DirectoryMethods.CreateADirectory(path);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenDeleteDirectoryIsCalled_ShouldDeletesDirectory()
        {
            // Act
            DirectoryMethods.DeleteDirectory(testDirectoryPath);

            // Assert
            Assert.False(Directory.Exists(testDirectoryPath));
        }

        public void Dispose()
        {
            // Clean up the test directory after tests
            if (Directory.Exists(testDirectoryPath))
            {
                Directory.Delete(testDirectoryPath, true);
            }
        }

    }
}

