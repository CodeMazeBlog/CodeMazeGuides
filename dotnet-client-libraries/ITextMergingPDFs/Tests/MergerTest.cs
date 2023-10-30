using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class MergerTest
    {
        private FolderManager _folderManager = default!;

        [TestInitialize]
        public void Initialize()
        {
            _folderManager = FolderManager.CreateFolderManagerInTemporaryFolder("Test");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _folderManager.DeletePDFDocumentsFolder();
        }

        [TestMethod]
        public void GivenValidParameters_WhenCreateMerger_ThenExpectOneMoreFile()
        {
            var numberOfDocuments = Random.Shared.Next(1, 20);
            var pageSize = PageSize.A4;

            var documents = BigDocument.CreateFewDocuments(_folderManager.PdfFolderName,
                "test", (uint)numberOfDocuments, pageSize).ToArray();

            Assert.IsNotNull(documents);
            var numberOfFilesInFolder = Directory.GetFiles(_folderManager.PdfFolderName).Length;
            Assert.AreEqual(numberOfDocuments, documents.Length);
            Assert.AreEqual(numberOfFilesInFolder, documents.Length);

            Merger.Merge(documents, _folderManager.GetFullName("merged.pdf"));
            numberOfFilesInFolder = Directory.GetFiles(_folderManager.PdfFolderName).Length;
            Assert.AreEqual(numberOfFilesInFolder, documents.Length + 1);
        }

        [TestMethod]
        public void GivenInValidParameters_WhenCreateMerger_ThenExpectException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Merger.Merge(Array.Empty<string>(), "merged"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Merger.Merge(new string[] { "test" }, "merged"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Merger.Merge(new string[] { "test", "test2" }, ""));
        }
    }
}
