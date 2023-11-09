using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class ResizerTest
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
        public void GivenValidParameters_WhenCreateResizer_ThenExpectOneMoreFile()
        {
            var pdfFileName = _folderManager.GetFullName("TestDocument.pdf");
            var folder = _folderManager.PdfFolderName;

            var document = BigDocument.CreateDocument(pdfFileName, PageSize.A4);

            Assert.IsNotNull(document);
            var numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(1, numberOfFilesInFolder);

            var newPdfFileName = _folderManager.GetFullName("ResizedDocument.pdf");
            Resizer.ResizeToA5(document, newPdfFileName);
            numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(2, numberOfFilesInFolder);
        }
    }
}
