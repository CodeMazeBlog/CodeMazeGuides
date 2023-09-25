using iText.Kernel.Geom;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class BigDocumentTest
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
        public void GivenValidParameters_WhenCreateDocumentInvoked_ThenExpectOneFile()
        {
            var pdfFileName = "TestDocument.pdf";
            var pageSize = PageSize.A4;

            var fullFilePath = _bigDocument.CreateDocument(pdfFileName, pageSize);

            Assert.IsNotNull(fullFilePath);
            Assert.IsTrue(File.Exists(fullFilePath));
            Assert.IsTrue(fullFilePath.EndsWith(pdfFileName));
        }

        [TestMethod]
        public void GivenValidParameters_WhenCreateFewDocumentsInvoked_ThenExpectFewDocumentsCreated()
        {
            var pdfFileNameMask = "TestDocument_{0}.pdf";
            var numberOfDocuments = 5u;
            var pageSize = PageSize.A4;

            var documents = _bigDocument.CreateFewDocuments(pdfFileNameMask, numberOfDocuments, pageSize);

            Assert.IsNotNull(documents);
            Assert.AreEqual(numberOfDocuments, (uint)documents.Length);

            for (int i = 0; i < numberOfDocuments; i++)
            {
                var currentDocument = documents[i];
                Assert.IsNotNull(currentDocument);
                Assert.IsTrue(File.Exists(currentDocument));
            }
        }

        [TestMethod]
        public void GivenInValidParameters_WhenCreateFewDocumentsInvoked_ThenExpectException()
        {
            var pdfFileNameMask = "TestDocument_{0}.pdf";
            var pageSize = PageSize.A4;

            var numberOfDocuments = 0u;
            Assert.ThrowsException<ArgumentException>(() => _bigDocument.CreateFewDocuments(pdfFileNameMask, numberOfDocuments, pageSize));

            numberOfDocuments = 21u;
            Assert.ThrowsException<ArgumentException>(() => _bigDocument.CreateFewDocuments(pdfFileNameMask, numberOfDocuments, pageSize));
        }
    }
}
