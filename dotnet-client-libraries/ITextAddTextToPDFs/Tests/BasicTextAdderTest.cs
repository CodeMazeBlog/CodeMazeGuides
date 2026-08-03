namespace Tests
{
    [TestClass]
    public class BasicTextAdderTest
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
        public void GivenValidName_WhenCallingCopy_ThenOneMoreFileShouldExist(string documentName)
        {
            var NumberOfFilesAtStart = 0;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var existingDocument = SampleDocument.Get(documentName);
            var existingDocumentNewName = _folderManager.CopyFile(existingDocument, documentName);
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());

            var nameOfCopiedFile = "NewDocument1";
            BasicTextAdder.Add(existingDocumentNewName, _folderManager.GetFullName(nameOfCopiedFile), "New text");
            ++NumberOfFilesAtStart;
            Assert.AreEqual(NumberOfFilesAtStart, _folderManager.CountFiles());
        }
    }
}