namespace Tests
{
    [TestClass]
    public class PathTypeWithAttributesIntegrationTest
    {
        [TestMethod]
        public void WhenPathIsDirectory_ThenHasDirectoryAttribute()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_directory_2");
            Directory.CreateDirectory(path);

            var attributes = File.GetAttributes(path);
            Assert.IsTrue(attributes.HasFlag(FileAttributes.Directory));
        }

        [TestMethod]
        public void WhenPathIsFile_ThenHasNotDirectoryAttribute()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_file_2.abc");
            File.CreateText(path);

            var attributes = File.GetAttributes(path);
            Assert.IsFalse(attributes.HasFlag(FileAttributes.Directory));
        }

        [TestMethod]
        public void WhenPathNotExists_ThenThrowsException()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_not_existing_2.abc");

            Assert.ThrowsException<FileNotFoundException>(() => { var attributes = File.GetAttributes(path); });
        }
    }
}
