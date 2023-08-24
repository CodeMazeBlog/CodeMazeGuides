using System.IO.Compression;
using ZipFilesInNet;

namespace Tests
{
    [TestClass]
    public class CreateZipFileTest
    {
        private string _sourceZipFile = string.Empty;
        private string _destinationZipFile = string.Empty;
        private string _tempFolder = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            _sourceZipFile = "multi-folder.zip";
            _destinationZipFile = "multi-folder-test.zip";
            _tempFolder = Path.GetTempPath() + Guid.NewGuid();

            File.Delete(_destinationZipFile);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Directory.Delete(_tempFolder, true);
            File.Delete(_destinationZipFile);
        }

        [TestMethod]
        public void GivenZipFile_WhenExtractingItAndZippingIt_ThenFilesShuldContainSameFiles()
        {
            ZipFile.ExtractToDirectory(_sourceZipFile, _tempFolder);

            var create = new CreateZipFiles();
            create.CreateZipFromFolderUsingAlgorithm(_destinationZipFile, _tempFolder);

            using var src = ZipFile.OpenRead(_sourceZipFile);
            using var dest = ZipFile.OpenRead(_destinationZipFile);
            var srcFiles = src.Entries.Where(e => !string.IsNullOrEmpty(e.Name)).Select(e => Path.GetFullPath(e.FullName)).ToArray();
            var destFiles = dest.Entries.Where(e => !string.IsNullOrEmpty(e.Name)).Select(e => Path.GetFullPath(e.FullName)).ToArray();

            CollectionAssert.AreEquivalent(srcFiles, destFiles);
        }
    }
}
