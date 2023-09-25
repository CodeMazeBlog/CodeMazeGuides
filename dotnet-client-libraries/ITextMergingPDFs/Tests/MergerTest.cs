using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class MergerTest
    {
        private BigDocument _bigDocument = default!;
        private FolderManager _folderManager = default!;
        private Merger _pdfMerger = default!;
        private readonly Random _random = new();

        [TestInitialize]
        public void Initialize()
        {
            _folderManager = FolderManager.CreateFolderManagerInTemporaryFolder("Test");
            _bigDocument = BigDocument.Create(_folderManager.EnsurePFDDocumentsFolderExists());
            _pdfMerger = Merger.Create(_folderManager.EnsurePFDDocumentsFolderExists());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _folderManager.DeletePFDDocumentsFolder();
        }

        [TestMethod]
        public void GivenValidParameters_WhenCreateMerger_ThenExpectOneMoreFile()
        {
            var pdfFileNameMask = "TestDocument_{0}.pdf";
            var numberOfDocuments = _random.Next(1, 20);
            var pageSize = PageSize.A4;
            var folder = _folderManager.EnsurePFDDocumentsFolderExists();

            var documents = _bigDocument.CreateFewDocuments(pdfFileNameMask, (uint)numberOfDocuments, pageSize);

            Assert.IsNotNull(documents);
            var numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfDocuments, documents.Length);
            Assert.AreEqual(numberOfFilesInFolder, documents.Length);

            _pdfMerger.MergePDFs(documents, "merged.pdf");
            numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, documents.Length + 1);
        }

        [TestMethod]
        public void GivenValidDocument_WhenUsingSplitter_ThenExpectTwoDocuments()
        {
            var folder = _folderManager.EnsurePFDDocumentsFolderExists();

            var document = _bigDocument.CreateDocument("TestDocument", PageSize.A6);

            Assert.IsNotNull(document);
            var numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, 1);

            _pdfMerger.SplitDocument(document);
            numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, 3);
        }

        [TestMethod]
        public void GivenInValidParameters_WhenCreateMerger_ThenExpectException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _pdfMerger.MergePDFs(Array.Empty<string>(), "merged"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _pdfMerger.MergePDFs(new string[] { "test" }, "merged"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _pdfMerger.MergePDFs(new string[] { "test", "test2" }, ""));
        }
    }
}
