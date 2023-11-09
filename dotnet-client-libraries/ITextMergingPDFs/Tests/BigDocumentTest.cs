using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class BigDocumentTest
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
        public void GivenValidParameters_WhenCreateDocumentInvoked_ThenExpectOneFile()
        {
            var pdfFileName = _folderManager.GetFullName("TestDocument.pdf");
            var pageSize = PageSize.A4;

            var fullFilePath = BigDocument.CreateDocument(pdfFileName, pageSize);

            Assert.IsNotNull(fullFilePath);
            Assert.IsTrue(File.Exists(fullFilePath));
            Assert.IsTrue(fullFilePath.EndsWith(pdfFileName));
        }

        [TestMethod]
        public void GivenValidParameters_WhenCreateFewDocumentsInvoked_ThenExpectFewDocumentsCreated()
        {
            var numberOfDocuments = 5u;
            var pageSize = PageSize.A4;

            var documents = BigDocument.CreateFewDocuments(_folderManager.PdfFolderName,
                "test", numberOfDocuments, pageSize).ToArray();

            Assert.IsNotNull(documents);
            Assert.AreEqual(numberOfDocuments, (uint)documents.Length);

            for (var i = 0; i < numberOfDocuments; i++)
            {
                var currentDocument = documents[i];
                Assert.IsNotNull(currentDocument);
                Assert.IsTrue(File.Exists(currentDocument));
            }
        }

        [TestMethod]
        public void GivenInValidParameters_WhenCreateFewDocumentsInvoked_ThenExpectnoDocuments()
        {
            var pageSize = PageSize.A4;

            var numberOfDocuments = 0u;
            var documents = BigDocument.CreateFewDocuments(_folderManager.PdfFolderName,
                "test", numberOfDocuments, pageSize).ToArray();

            Assert.AreEqual(0, documents.Length);
        }
    }
}
