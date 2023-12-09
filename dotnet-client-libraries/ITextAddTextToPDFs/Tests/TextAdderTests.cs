using iText.Kernel.Colors;
using ITextAddTextToPDFs;

namespace Tests
{
    [TestClass]
    public class TextAdderTests
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
        [DataRow("PictureDocument.pdf")]
        [DataRow("TextDocument.pdf")]
        public void GivenValidName_WhenCallingCopyWithText_ThenOneMoreFileShouldExist(string documentName)
        {
            var NumberOfFilesAtStart = 0;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var existingDocument = SampleDocument.Get(documentName);
            var existingDocumentNewName = _folderManager.CopyFile(existingDocument, documentName);
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var nameOfCopiedFile = "NewDocument1";
            var copier = new TextAdder(existingDocumentNewName, _folderManager.GetFullName(nameOfCopiedFile));
            copier.Add("This is new text");
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());
        }

        [TestMethod]
        [DataRow("PictureDocument.pdf")]
        [DataRow("TextDocument.pdf")]
        public void GivenValidName_WhenCallingCopyWithCenterText_ThenOneMoreFileShouldExist(string documentName)
        {
            var NumberOfFilesAtStart = 0;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var existingDocument = SampleDocument.Get(documentName);
            var existingDocumentNewName = _folderManager.CopyFile(existingDocument, documentName);
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var nameOfCopiedFile = "NewDocument1";
            var copier = new TextAdder(existingDocumentNewName, _folderManager.GetFullName(nameOfCopiedFile));
            copier.AddCenterText("This is new text", 30, 50, ColorConstants.RED);

            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());
        }

        [TestMethod]
        [DataRow("PictureDocument.pdf")]
        [DataRow("TextDocument.pdf")]
        public void GivenValidName_WhenCallingCopyWithWatermark_ThenOneMoreFileShouldExist(string documentName)
        {
            var NumberOfFilesAtStart = 0;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var existingDocument = SampleDocument.Get(documentName);
            var existingDocumentNewName = _folderManager.CopyFile(existingDocument, documentName);
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var nameOfCopiedFile = "NewDocument1";
            var copier = new TextAdder(existingDocumentNewName, _folderManager.GetFullName(nameOfCopiedFile));
            copier.AddWatermark("This is new text", 30, 50, ColorConstants.RED);

            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());
        }

        [TestMethod]
        [DataRow("PictureDocument.pdf")]
        [DataRow("TextDocument.pdf")]
        public void GivenValidName_WhenCallingCopy_ThenOneMoreFileShouldExist(string documentName)
        {
            var NumberOfFilesAtStart = 0;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var existingDocument = SampleDocument.Get(documentName);
            var existingDocumentNewName = _folderManager.CopyFile(existingDocument, documentName);
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var nameOfCopiedFile = "NewDocument1";
            var copier = new TextAdder(existingDocumentNewName, _folderManager.GetFullName(nameOfCopiedFile));
            copier.AddHeaders();

            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());
        }
    }
}