namespace Tests
{
    [TestClass]
    public class PathTypeWithPathExistsIntegrationTest
    {
        [TestMethod]
        public void WhenPathIsDirectory_ThenPathExistsIsTrue()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_directory_4");
            Directory.CreateDirectory(path);

            Assert.IsTrue(Path.Exists(path));
        }

        [TestMethod]
        public void WhenPathIsFile_ThenPathExistsIsTrue()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_file_4.abc");
            File.WriteAllText(path, string.Empty);

            Assert.IsTrue(Path.Exists(path));
        }

        [TestMethod]
        public void WhenPathNotExists_ThenPathExistsIsFalse()
        {
            string path = Path.Combine(Path.GetTempPath(), "test_not_existing_4.abc");

            Assert.IsFalse(Path.Exists(path));
        }
    }
}
