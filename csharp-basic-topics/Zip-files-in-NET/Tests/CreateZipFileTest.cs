using System.IO.Compression;
using Zip_files_in_NET;

namespace Tests
{
    [TestClass]
    public class CreateZipFileTest
    {
        [TestInitialize]
        public void Initialize()
        {
            sourceZipFile = "multi-folder.zip";
            destinationZipFile = "multi-folder-test.zip";
            tempFolder = Path.GetTempPath() + Guid.NewGuid();

            File.Delete(destinationZipFile);
        }

        [TestCleanup] 
        public void Cleanup() 
        {
            Directory.Delete(tempFolder, true);
            File.Delete(destinationZipFile);
        }

        [TestMethod]
        public void GivenZipFile_WhenExtractingItAndZippingIt_ThenFilesShuldContainSameFiles()
        {
            ZipFile.ExtractToDirectory(sourceZipFile, tempFolder);

            var create = new CreateZipFiles();
            create.CreateZipFromFolderUsingAlgorithm(destinationZipFile, tempFolder);

            using var src = ZipFile.OpenRead(sourceZipFile);
            using var dest = ZipFile.OpenRead(destinationZipFile);
            var srcFiles = src.Entries.Where(e => !string.IsNullOrEmpty(e.Name)).Select(e => Path.GetFullPath(e.FullName)).ToArray();
            var destFiles = dest.Entries.Where(e => !string.IsNullOrEmpty(e.Name)).Select(e => Path.GetFullPath(e.FullName)).ToArray();
            CollectionAssert.AreEquivalent(srcFiles, destFiles);
        }

        private string sourceZipFile = string.Empty;
        private string destinationZipFile = string.Empty;
        private string tempFolder = string.Empty;
    }
}
