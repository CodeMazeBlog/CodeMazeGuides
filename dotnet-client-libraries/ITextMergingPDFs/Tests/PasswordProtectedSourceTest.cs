using System.Text;
using iText.Kernel.Exceptions;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class PasswordProtectedSourceTest
    {
        private FolderManager _folderManager = default!;

        [TestInitialize]
        public void Initialize()
        {
            _folderManager = FolderManager.CreateFolderManagerInTemporaryFolder("TestProtected");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _folderManager.DeletePDFDocumentsFolder();
        }

        private string CreateProtectedDocument()
        {
            var plainFile = BigDocument.CreateDocument(_folderManager.GetFullName("plain.pdf"), PageSize.A4);
            var protectedFile = _folderManager.GetFullName("protected.pdf");

            var writerProperties = new WriterProperties().SetStandardEncryption(
                Encoding.ASCII.GetBytes("user-password"), Encoding.ASCII.GetBytes("owner-password"),
                EncryptionConstants.ALLOW_PRINTING, EncryptionConstants.ENCRYPTION_AES_256);

            using var reader = new PdfReader(plainFile);
            using var writer = new PdfWriter(protectedFile, writerProperties);
            using var pdfDocument = new PdfDocument(reader, writer);

            return protectedFile;
        }

        [TestMethod]
        public void GivenProtectedSource_WhenOpenedWithoutPassword_ThenExpectBadPasswordException()
        {
            var file = CreateProtectedDocument();

            Assert.ThrowsExactly<BadPasswordException>(() =>
            {
                using var reader = new PdfReader(file);
                using var srcPdfDocument = new PdfDocument(reader);
            });
        }

        [TestMethod]
        public void GivenProtectedSource_WhenOpenedWithPassword_ThenExpectMergedPages()
        {
            var file = CreateProtectedDocument();
            var mergedFile = _folderManager.GetFullName("merged.pdf");
            int expectedPages;

            using (var writer = new PdfWriter(mergedFile))
            using (var mergedPdfDocument = new PdfDocument(writer))
            {
                var pdfMerger = new PdfMerger(mergedPdfDocument);

                var readerProperties = new ReaderProperties()
                    .SetPassword(Encoding.ASCII.GetBytes("owner-password"));
                using var reader = new PdfReader(file, readerProperties);
                using var srcPdfDocument = new PdfDocument(reader);
                pdfMerger.Merge(srcPdfDocument, 1, srcPdfDocument.GetNumberOfPages());
                expectedPages = srcPdfDocument.GetNumberOfPages();
            }

            using var resultReader = new PdfReader(mergedFile);
            using var result = new PdfDocument(resultReader);
            Assert.AreEqual(expectedPages, result.GetNumberOfPages());
        }
    }
}
