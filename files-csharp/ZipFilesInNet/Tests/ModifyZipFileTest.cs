using System.IO.Compression;
using System.Text.RegularExpressions;
using ZipFilesInNet;

namespace Tests
{
    [TestClass]
    public class ModifyZipFileTest
    {
        private string _sourceZipFile = string.Empty;
        private string _tempZipFile = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            _sourceZipFile = "multi-folder.zip";
            _tempZipFile = "multi-folder-test.zip";

            File.Delete(_tempZipFile);
            File.Copy(_sourceZipFile, _tempZipFile);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_tempZipFile);
        }

        [TestMethod]
        public void GivenZipFile_WhenExtractingItAndZippingIt_ThenFilesShuldContainSameFiles()
        {
            var pattern = "*.png";

            var modify = new ModifyZipFiles();
            modify.DeleteFilesFromZipFile(_tempZipFile, pattern);

            using var src = ZipFile.OpenRead(_sourceZipFile);
            using var dest = ZipFile.OpenRead(_tempZipFile);
            var srcFilesCount = src.Entries.Count(e => IsPatternMach(e.Name, pattern));
            var destFilesCount = dest.Entries.Count(e => IsPatternMach(e.Name, pattern));

            Assert.IsTrue(srcFilesCount > 0);
            Assert.IsTrue(destFilesCount == 0);
        }

        private static bool IsPatternMach(string fileName, string filePattern)
        {
            Regex regPattern = new(
                filePattern.Replace(".", "[.]")
                    .Replace("*", ".*")
                    .Replace("?", "."));

            return regPattern.IsMatch(fileName);
        }
    }
}
