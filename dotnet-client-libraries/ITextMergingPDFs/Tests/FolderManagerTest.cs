using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class FolderManagerTests
    {
        [TestMethod]
        public void GivenFolderNameTest_WhenCreatingPdfFolder_ThenExpectFolderCreated()
        {
            var subFolderName = "Test";
            var folderManager = FolderManager.CreateFolderManagerInTemporaryFolder(subFolderName);
            var expectedFolder = Path.Combine(Path.GetTempPath(), subFolderName);

            var result = folderManager.PdfFolderName;

            Assert.IsTrue(Directory.Exists(result));
            Assert.AreEqual(expectedFolder, result);

            Directory.Delete(expectedFolder, true);
            Assert.IsFalse(Directory.Exists(result));
        }

        [TestMethod]
        public void GivenFolderManager_WhenDeletingPdfFolder_ThenExpectFolderToNotExistAnymore()
        {
            var subFolderName = "Test";
            var folderManager = FolderManager.CreateFolderManagerInTemporaryFolder(subFolderName);
            var newFolder = Path.Combine(Path.GetTempPath(), subFolderName);

            folderManager.EnsurePFDDocumentsFolderExists();
            Assert.IsTrue(Directory.Exists(newFolder));

            folderManager.DeletePDFDocumentsFolder();
            Assert.IsFalse(Directory.Exists(newFolder));
        }
    }
}
