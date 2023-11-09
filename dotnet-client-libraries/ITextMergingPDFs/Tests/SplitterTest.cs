using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class SplitterTest
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
        public void GivenValidDocument_WhenUsingSplitter_ThenExpectTwoDocuments()
        {
            var pdfFileName = _folderManager.GetFullName("TestDocument.pdf");
            var document = BigDocument.CreateDocument(pdfFileName, PageSize.A6);

            Assert.IsNotNull(document);
            var numberOfFilesInFolder = Directory.GetFiles(_folderManager.PdfFolderName).Length;
            Assert.AreEqual(1, numberOfFilesInFolder);

            Splitter.Split(document);
            numberOfFilesInFolder = Directory.GetFiles(_folderManager.PdfFolderName).Length;
            Assert.AreEqual(3, numberOfFilesInFolder);
        }
    }
}
