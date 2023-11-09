using iText.Kernel.Exceptions;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using ITextMergingPDFs;

namespace Tests
{
    [TestClass]
    public class SetCloseSourceDocumentsTest
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
        public void GivenFalseParameter_WhenCallingSetCloseSourceDocuments_ThenExpectDocumentToStayOpen()
        {
            var pdfFileName = _folderManager.GetFullName("TestDocument.pdf");
            var sourcePdf = BigDocument.CreateDocument(pdfFileName, PageSize.A4);
            var mergedPdf = _folderManager.GetFullName("result.pdf");

            using var writer = new PdfWriter(mergedPdf);
            using var mergedPdfDocument = new PdfDocument(writer);

            using var reader = new PdfReader(sourcePdf);
            using var sourcePdfDocument = new PdfDocument(reader);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            pdfMerger.SetCloseSourceDocuments(false);

            pdfMerger.Merge(sourcePdfDocument, 1, sourcePdfDocument.GetNumberOfPages());

            // document is open, so we can use it
            Assert.IsTrue(sourcePdfDocument.GetNumberOfPages() > 0);
        }

        [TestMethod]
        public void GivenTrueParameter_WhenCallingSetCloseSourceDocuments_ThenExpectAutomaticCloseOfDocument()
        {
            var pdfFileName = _folderManager.GetFullName("TestDocument.pdf");
            var sourcePdf = BigDocument.CreateDocument(pdfFileName, PageSize.A4);
            var mergedPdf = _folderManager.GetFullName("result.pdf");

            using var writer = new PdfWriter(mergedPdf);
            using var mergedPdfDocument = new PdfDocument(writer);

            using var reader = new PdfReader(sourcePdf);
            using var sourcePdfDocument = new PdfDocument(reader);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            pdfMerger.SetCloseSourceDocuments(true);

            pdfMerger.Merge(sourcePdfDocument, 1, sourcePdfDocument.GetNumberOfPages());

            // document is not open, we can't use it
            Assert.ThrowsException<PdfException>(() => { sourcePdfDocument.GetNumberOfPages(); });
        }

        [TestMethod]
        public void GivenNoParameter_WhenCallingSetCloseSourceDocuments_ThenExpectDocumentToStayOpen()
        {
            var pdfFileName = _folderManager.GetFullName("TestDocument.pdf");
            var sourcePdf = BigDocument.CreateDocument(pdfFileName, PageSize.A4);
            var mergedPdf = _folderManager.GetFullName("result.pdf");

            using var writer = new PdfWriter(mergedPdf);
            using var mergedPdfDocument = new PdfDocument(writer);

            using var reader = new PdfReader(sourcePdf);
            using var sourcePdfDocument = new PdfDocument(reader);

            var pdfMerger = new PdfMerger(mergedPdfDocument);

            pdfMerger.Merge(sourcePdfDocument, 1, sourcePdfDocument.GetNumberOfPages());

            // document is open, so we can use it
            Assert.IsTrue(sourcePdfDocument.GetNumberOfPages() > 0);
        }
    }
}
