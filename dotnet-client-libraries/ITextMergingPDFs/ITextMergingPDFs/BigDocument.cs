using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ITextMergingPDFs.Text;

namespace ITextMergingPDFs
{
    public class BigDocument
    {
        private static readonly PageSize[] _pageSizes = new PageSize[] { PageSize.A1, PageSize.A2, PageSize.A3, PageSize.A4, PageSize.A5, PageSize.A6 };

        private readonly string _path;

        public BigDocument(string? path)
        {
            _path = path ?? System.IO.Path.GetTempPath();
        }

        public string CreateDocument(string pdfFileName, PageSize pageSize)
        {
            var fullFilename = System.IO.Path.Combine(_path, pdfFileName);
            using var writer = new PdfWriter(fullFilename);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, pageSize, immediateFlush: false);

            try
            {
                AddContent(document, pdfFileName);
                PageXofYFooter(pdfDocument, document, pdfFileName);
            }
            finally
            {
                document.Close();
            }

            return fullFilename;
        }

        public string[] CreateFewDocuments(string pdfFileNameMask, uint numberOfDocuments, PageSize? pageSize = null)
        {
            if ((numberOfDocuments < 1) || (numberOfDocuments > 20))
                throw new ArgumentException("Number of documents must be between 1 and 20", nameof(numberOfDocuments));

            var documents = new string[numberOfDocuments];
            for (var i = 0; i < numberOfDocuments; i++)
            {
                var fileNameWithNumber = string.Format(pdfFileNameMask, i);
                documents[i] = CreateDocument(fileNameWithNumber, pageSize ?? GetRandomPageSize());
            }

            return documents;
        }

        private static void AddContent(Document document, string caption, int numberOfRepetitions = 3)
        {
            document.Add(CreateHeader1($"This is document with the name {caption}"));
            document.Add(CreateHeader1(""));
            document.Add(CreateHeader1(""));
            for (var i = 0; i < numberOfRepetitions; i++)
            {
                document.Add(CreateHeader1(LoremIpsumGenerator.GenerateWords(3)));
                document.Add(CreateHeader2(LoremIpsumGenerator.GenerateWords(7)));
                document.Add(CreateNormalParagraph(LoremIpsumGenerator.GenerateRandomNumberOfWords()));

                document.Add(CreateHeader2(LoremIpsumGenerator.GenerateWords(7)));
                document.Add(CreateNormalParagraph(LoremIpsumGenerator.GenerateRandomNumberOfWords()));
                document.Add(CreateNormalParagraph(LoremIpsumGenerator.GenerateRandomNumberOfWords()));

                document.Add(CreateHeader1(LoremIpsumGenerator.GenerateWords(6)));
                document.Add(CreateHeader2(LoremIpsumGenerator.GenerateWords(3)));
                document.Add(CreateNormalParagraph(LoremIpsumGenerator.GenerateRandomNumberOfWords()));
                document.Add(CreateHeader2(LoremIpsumGenerator.GenerateWords(3)));
                document.Add(CreateNormalParagraph(LoremIpsumGenerator.GenerateRandomNumberOfWords()));
            }
        }

        private static Paragraph CreateHeader1(string caption)
        {
            return new Paragraph(caption)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20)
                .SetBold();
        }

        private static Paragraph CreateHeader2(string caption)
        {
            return new Paragraph(caption)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15)
                .SetBold();
        }

        private static Paragraph CreateNormalParagraph(string text)
        {
            return new Paragraph(text);
        }

        private static void PageXofYFooter(PdfDocument pdfDocument, Document document, string fileName)
        {
            var numPages = pdfDocument.GetNumberOfPages();
            for (var pageId = 1; pageId <= numPages; pageId++)
            {
                var page = pdfDocument.GetPage(pageId);
                var centerPage = page.GetPageSize().GetWidth() / 2;

                var paragraph = new Paragraph($"File {fileName} / Page {pageId} of {numPages}");
                document.ShowTextAligned(paragraph, centerPage, UnitConverter.mm2uu(10), pageId,
                    TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
            }
        }

        private static PageSize GetRandomPageSize()
        {
            var index = Random.Shared.Next(0, _pageSizes.Length);
            return _pageSizes[index];
        }
    }
}
