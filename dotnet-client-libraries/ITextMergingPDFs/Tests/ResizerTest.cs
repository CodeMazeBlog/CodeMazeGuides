using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class ResizerTest
    {
        private BigDocument _bigDocument = default!;
        private FolderManager _folderManager = default!;
        private Resizer _resizer = default!;

        [TestInitialize]
        public void Initialize()
        {
            _folderManager = FolderManager.CreateFolderManagerInTemporaryFolder("Test");
            _bigDocument = BigDocument.Create(_folderManager.EnsurePFDDocumentsFolderExists());
            _resizer = Resizer.Create(_folderManager.EnsurePFDDocumentsFolderExists());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _folderManager.DeletePFDDocumentsFolder();
        }

        [TestMethod]
        public void GivenValidParameters_WhenCreateResizer_ThenExpectOneMoreFile()
        {
            var pdfFileNameMask = "TestDocument.pdf";
            var folder = _folderManager.EnsurePFDDocumentsFolderExists();

            var document = _bigDocument.CreateDocument(pdfFileNameMask, PageSize.A4);

            Assert.IsNotNull(document);
            var numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, 1);

            _resizer.ResizeFromA4ToA5(document, "resized.pdf");
            numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, 2);
        }
    }
}
