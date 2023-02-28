using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zip_files_in_NET;

namespace Tests
{
    [TestClass]
    public class ModifyZipFileTest
    {
        [TestInitialize]
        public void Initialize()
        {
            sourceZipFile = "multi-folder.zip";
            tempZipFile = "multi-folder-test.zip";

            File.Delete(tempZipFile);
            File.Copy(sourceZipFile, tempZipFile);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(tempZipFile);
        }

        [TestMethod]
        public void GivenZipFile_WhenExtractingItAndZippingIt_ThenFilesShuldContainSameFiles()
        {
            var pattern = "*.png";

            var modify = new ModifyZipFiles();
            modify.DeleteFilesFromZipFile(tempZipFile, pattern);

            using var src = ZipFile.OpenRead(sourceZipFile);
            using var dest = ZipFile.OpenRead(tempZipFile);
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

        private string sourceZipFile = string.Empty;
        private string tempZipFile = string.Empty;
    }
}
