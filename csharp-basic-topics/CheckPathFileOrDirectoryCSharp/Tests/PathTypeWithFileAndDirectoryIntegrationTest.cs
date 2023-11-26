namespace Tests
{
    [TestClass]
    public class PathTypeWithFileAndDirectoryIntegrationTest
    {
        [TestMethod]
        public void WhenPathIsDirectory_ThenDirectoryExistsIsTrue()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_directory_1.abc");
            Directory.CreateDirectory(path);

            Assert.IsTrue(Directory.Exists(path));
            Assert.IsFalse(File.Exists(path));
        }

        [TestMethod]
        public void WhenPathIsFile_ThenFileExistsIsTrue()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_file_1.abc");
            File.CreateText(path);

            Assert.IsFalse(Directory.Exists(path));
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void WhenPathNotExists_ThenExistsIsFalse()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_not_existing_1.abc");

            Assert.IsFalse(Directory.Exists(path));
            Assert.IsFalse(File.Exists(path));
        }
    }
}
