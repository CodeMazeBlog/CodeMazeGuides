namespace Tests
{
    [TestClass]
    public class PathTypeWithFileInfoAndDirectoryInfoIntegrationTest
    {
        [TestMethod]
        public void WhenPathIsDirectory_ThenDirectoryExistsIsTrue()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_directory_3");
            Directory.CreateDirectory(path);

            var fileInfo = new FileInfo(path);
            var directoryInfo = new DirectoryInfo(path);

            Assert.IsTrue(directoryInfo.Exists);
            Assert.IsFalse(fileInfo.Exists);
        }

        [TestMethod]
        public void WhenPathIsFile_ThenFileExistsIsTrue()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_file_3.abc");
            File.CreateText(path);

            var fileInfo = new FileInfo(path);
            var directoryInfo = new DirectoryInfo(path);

            Assert.IsFalse(directoryInfo.Exists);
            Assert.IsTrue(fileInfo.Exists);
        }

        [TestMethod]
        public void WhenPathNotExists_ThenExistsIsFalse()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_not_existing_3.abc");

            var fileInfo = new FileInfo(path);
            var directoryInfo = new DirectoryInfo(path);

            Assert.IsFalse(directoryInfo.Exists);
            Assert.IsFalse(fileInfo.Exists);
        }
    }
}
