using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class MergerTest
    {
        private BigDocument _bigDocument = default!;
        private FolderManager _folderManager = default!;

        [TestInitialize]
        public void Initialize()
        {
            _folderManager = FolderManager.CreateFolderManagerInTemporaryFolder("Test");
            _bigDocument = BigDocument.Create(_folderManager.EnsurePFDDocumentsFolderExists());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _folderManager.DeletePFDDocumentsFolder();
        }

        [TestMethod]
        public void GivenValidDocument_WhenUsingSplitter_ThenExpectTwoDocuments()
        {
            var folder = _folderManager.EnsurePFDDocumentsFolderExists();

            var document = _bigDocument.CreateDocument("TestDocument", PageSize.A6);

            Assert.IsNotNull(document);
            var numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, 1);

            Splitter.Split(document);
            numberOfFilesInFolder = Directory.GetFiles(folder).Length;
            Assert.AreEqual(numberOfFilesInFolder, 3);
        }
    }
}
