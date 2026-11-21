using DirectoryAndDirectoryInfo;

namespace Tests
{
    public class DirectoryInfoMethodsTests : IDisposable
    {
        private readonly string _testDirectoryPath =
            Path.Combine(Path.GetTempPath(), "CM-Demos-Tests", Guid.NewGuid().ToString());

        public DirectoryInfoMethodsTests()
        {
            Directory.CreateDirectory(_testDirectoryPath);
        }

        [Fact]
        public void WhenCreateSubDirectoriesIsCalled_ShouldCreateSubDirectory()
        {
            var directoryInfoMethods = new DirectoryInfoMethods();
            var directoryInfo = new DirectoryInfo(_testDirectoryPath);
            var subDirectoryPath = Path.Combine(_testDirectoryPath, "SubFolder");

            directoryInfoMethods.CreateSubDirectories(directoryInfo, "SubFolder");

            Assert.True(Directory.Exists(subDirectoryPath));
        }

        [Fact]
        public void GivenMissingParent_WhenCreateSubDirectoriesIsCalled_ThenParentIsCreatedToo()
        {
            var directoryInfoMethods = new DirectoryInfoMethods();
            var parent = new DirectoryInfo(Path.Combine(_testDirectoryPath, "NotYetThere"));

            var subDirectory = directoryInfoMethods.CreateSubDirectories(parent, "SubFolder");

            Assert.True(Directory.Exists(parent.FullName));
            Assert.True(subDirectory.Exists);
        }

        [Fact]
        public void WhenSourceDirectoryInfoIsMoved_ShouldDeleteOldDirectoryPath()
        {
            var directoryInfoMethods = new DirectoryInfoMethods();
            var sourceDirectoryPath = Path.Combine(_testDirectoryPath, "Directory");
            var sourceDirectoryInfo = Directory.CreateDirectory(sourceDirectoryPath);
            var destDirectoryPath = Path.Combine(_testDirectoryPath, "NewDirectory");

            directoryInfoMethods.MoveDirectories(sourceDirectoryInfo, destDirectoryPath);

            Assert.False(Directory.Exists(sourceDirectoryPath));
            Assert.True(Directory.Exists(destDirectoryPath));
        }

        [Fact]
        public void GivenMovedDirectory_WhenTheSameReferenceIsUsed_ThenItPointsToTheNewPath()
        {
            var directoryInfoMethods = new DirectoryInfoMethods();
            var sourceDirectoryInfo = Directory.CreateDirectory(Path.Combine(_testDirectoryPath, "Directory"));
            File.WriteAllText(Path.Combine(sourceDirectoryInfo.FullName, "notes.txt"), "x");
            var subDirectory = sourceDirectoryInfo.CreateSubdirectory("SubFolder");

            directoryInfoMethods.MoveDirectories(sourceDirectoryInfo, Path.Combine(_testDirectoryPath, "NewDirectory"));

            Assert.Equal("NewDirectory", sourceDirectoryInfo.Name);
            Assert.Single(sourceDirectoryInfo.GetFiles());
            Assert.False(subDirectory.Exists);
            Assert.Throws<DirectoryNotFoundException>(() => subDirectory.GetFiles());
        }

        [Fact]
        public void GivenSubDirectoryOfItself_WhenMoveDirectoriesIsCalled_ThenIOExceptionIsThrown()
        {
            var directoryInfoMethods = new DirectoryInfoMethods();
            var sourceDirectoryInfo = Directory.CreateDirectory(Path.Combine(_testDirectoryPath, "Directory"));

            Assert.Throws<IOException>(() => directoryInfoMethods.MoveDirectories(
                sourceDirectoryInfo, Path.Combine(sourceDirectoryInfo.FullName, "NewDirectory")));
        }

        [Fact]
        public void WhenEnumerateDirectoriesIsCalled_ShouldPrintSubDirectoryNames()
        {
            var directoryInfoMethods = new DirectoryInfoMethods();
            var directoryInfo = new DirectoryInfo(_testDirectoryPath);
            directoryInfo.CreateSubdirectory("Archive");
            directoryInfo.CreateSubdirectory("SubFolder");
            var output = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(output);

            try
            {
                directoryInfoMethods.EnumerateDirectories(directoryInfo);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            var names = output.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(["Archive", "SubFolder"], names.Order());
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
