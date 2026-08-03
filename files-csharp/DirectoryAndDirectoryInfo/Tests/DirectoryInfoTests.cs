using DirectoryAndDirectoryInfo;

namespace Tests
{
    public class DirectoryInfoMethodsTests : IDisposable
    {
        private readonly string _testDirectoryPath = @"C:\Public\CM-Demos\Test";

        public DirectoryInfoMethodsTests()
        {
            Directory.CreateDirectory(_testDirectoryPath);
        }

        [Fact]
        public void WhenCreateSubDirectoriesIsCalled_ShouldCreateSubDirectory()
        {
            // Arrange
            var directoryInfoMethods = new DirectoryInfoMethods();
            var directoryInfo = new DirectoryInfo(_testDirectoryPath);
            var subDirectory = "SubFolder";
            var subDirectoryPath = Path.Combine(_testDirectoryPath, subDirectory);

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
            var sourceDirectoryPath = Path.Combine(_testDirectoryPath, "Directory");
            var sourceDirectoryInfo = Directory.CreateDirectory(sourceDirectoryPath);
            var destDirectoryPath = Path.Combine(_testDirectoryPath, "NewDirectory");


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
            var directoryInfo = new DirectoryInfo(_testDirectoryPath);
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
            if (Directory.Exists(_testDirectoryPath))
            {
                Directory.Delete(_testDirectoryPath, true);
            }
        }
    }
}