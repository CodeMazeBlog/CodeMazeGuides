using Directory_And_DirectoryInfo;

namespace Tests
{
    public class DirectoryInfoMethodsTests : IDisposable
    {
        private readonly string testDirectoryPath = @"C:\Public\CM-Demos\Test";

        public DirectoryInfoMethodsTests()
        {
            Directory.CreateDirectory(testDirectoryPath);
        }

        [Fact]
        public void WhenCreateSubDirectoriesIsCalled_ShouldCreateSubDirectory()
        {
            // Arrange
            var directoryInfoMethods = new DirectoryInfoMethods();
            var directoryInfo = new DirectoryInfo(testDirectoryPath);
            var subDirectory = "SubFolder";
            var subDirectoryPath = Path.Combine(testDirectoryPath, subDirectory);

            // Act
            directoryInfoMethods.CreateSubDirectories(directoryInfo, subDirectory);

            // Assert
            Assert.True(Directory.Exists(subDirectoryPath));
        }

        [Fact]
        public void WhenSourceDirectoryInfoIsMoved_ShouldDeleteOldDirectoryPath()
        {
            // Arrange
            var directoryInfoMethods = new DirectoryInfoMethods();
            var sourceDirectoryPath = Path.Combine(testDirectoryPath, "Directory");
            var sourceDirectoryInfo = Directory.CreateDirectory(sourceDirectoryPath);
            var destDirectoryPath = Path.Combine(testDirectoryPath, "NewDirectory");


            // Act
            directoryInfoMethods.MoveDirectories(sourceDirectoryInfo, destDirectoryPath);

            // Assert
            Assert.False(Directory.Exists(sourceDirectoryPath));
            Assert.True(Directory.Exists(destDirectoryPath));
        }

        [Fact]
        public void WhenEnumerateDirectoriesIsCalled_ShouldPrintSubDirectoriesToConsole()
        {
            // Arrange
            var directoryMethods = new DirectoryInfoMethods();
            var directoryInfo = new DirectoryInfo(testDirectoryPath);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            directoryMethods.EnumerateDirectories(directoryInfo);

            // Assert
            if (!directoryInfo.GetDirectories().Any())
                Assert.Equal(string.Empty, output.ToString());
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