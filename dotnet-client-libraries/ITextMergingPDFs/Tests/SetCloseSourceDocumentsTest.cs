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
        private BigDocument _bigDocument = default!;
        private FolderManager _folderManager = default!;
        private string _folder = default!;

        [TestInitialize]
        public void Initialize()
        {
            _folderManager = FolderManager.CreateFolderManagerInTemporaryFolder("Test");
            _bigDocument = new BigDocument(_folderManager.PdfFolderName);
            _folder = _folderManager.PdfFolderName;
        }

        [TestCleanup]
        public void Cleanup()
        {
            _folderManager.DeletePDFDocumentsFolder();
        }

        [TestMethod]
        public void GivenFalseParameter_WhenCallingSetCloseSourceDocuments_ThenExpectDocumentToStayOpen()
        {
            var sourcePdf = _bigDocument.CreateDocument("TestDocument.pdf", PageSize.A4);
            var mergedPdf = System.IO.Path.Combine(_folder, "result.pdf");

            using var writer = new PdfWriter(mergedPdf);
            using var mergedPdfDocument = new PdfDocument(writer);

            using var reader = new PdfReader(sourcePdf);
            using var sourcePdfDocument = new PdfDocument(reader);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            pdfMerger.SetCloseSourceDocuments(false);

            pdfMerger.Merge(sourcePdfDocument, 1, sourcePdfDocument.GetNumberOfPages());

            // document is open, so we can use it
            var numberOfPages = sourcePdfDocument.GetNumberOfPages();
        }

        [TestMethod]
        public void GivenTrueParameter_WhenCallingSetCloseSourceDocuments_ThenExpectAutomaticCloseOfDocument()
        {
            var sourcePdf = _bigDocument.CreateDocument("TestDocument.pdf", PageSize.A4);
            var mergedPdf = System.IO.Path.Combine(_folder, "result.pdf");

            using var writer = new PdfWriter(mergedPdf);
            using var mergedPdfDocument = new PdfDocument(writer);

            using var reader = new PdfReader(sourcePdf);
            using var sourcePdfDocument = new PdfDocument(reader);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            pdfMerger.SetCloseSourceDocuments(true);

            pdfMerger.Merge(sourcePdfDocument, 1, sourcePdfDocument.GetNumberOfPages());

            // document is not open, we can't use it
            Assert.ThrowsException<PdfException>(() => { var numberOfPages = sourcePdfDocument.GetNumberOfPages(); });
        }

        [TestMethod]
        public void GivenNoParameter_WhenCallingSetCloseSourceDocuments_ThenExpectDocumentToStayOpen()
        {
            var sourcePdf = _bigDocument.CreateDocument("TestDocument.pdf", PageSize.A4);
            var mergedPdf = System.IO.Path.Combine(_folder, "result.pdf");

            using var writer = new PdfWriter(mergedPdf);
            using var mergedPdfDocument = new PdfDocument(writer);

            using var reader = new PdfReader(sourcePdf);
            using var sourcePdfDocument = new PdfDocument(reader);

            var pdfMerger = new PdfMerger(mergedPdfDocument);

            pdfMerger.Merge(sourcePdfDocument, 1, sourcePdfDocument.GetNumberOfPages());

            // document is open, so we can use it
            var numberOfPages = sourcePdfDocument.GetNumberOfPages();
        }
    }
}
