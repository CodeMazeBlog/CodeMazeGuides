namespace Tests
{
    [TestClass]
    public class SampleDocumentTest
    {
        [TestMethod]
        [DataRow("PictureDocument.pdf")]
        [DataRow("TextDocument.pdf")]
        public void GivenValidName_WhenSearchingSampleDocuments_ThenFileShouldExists(string documentName)
        {
            var _ = SampleDocument.Get(documentName);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataRow("file1.txt")]
        [DataRow("file2.txt")]
        public void GivenInvalidName_WhenSearchingSampleDocuments_ThenErrorShouldBeThrown(string documentName)
        {
            Assert.ThrowsException<FileNotFoundException>(() => SampleDocument.Get(documentName));
        }

        [TestMethod]
        [DataRow("PictureDocument.pdf", "file3.txt")]
        [DataRow("PictureDocument.pdf", "file4.txt")]
        public void GivenFileName_WhenCreatingSampleDocuments_ThenPathShouldBeEqual(
            string existingFile, string newFile)
        {
            var existingDirectory = Path.GetDirectoryName(SampleDocument.Get(existingFile));
            var newDirectory = Path.GetDirectoryName(SampleDocument.CreateFile(newFile));

            Assert.AreEqual(existingDirectory, newDirectory);
        }
    }
}