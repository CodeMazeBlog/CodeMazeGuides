using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ITextMergingPDFs.Text;
using Path = System.IO.Path;

namespace ITextMergingPDFs
{
    public static class BigDocument
    {
        private static readonly PageSize[] _pageSizes = new PageSize[] {
            PageSize.A1, PageSize.A2, PageSize.A3, PageSize.A4, PageSize.A5, PageSize.A6
        };

        public static string CreateDocument(string pdfFileName, PageSize pageSize)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, pageSize, immediateFlush: false);

            try
            {
                var onlyNameOfTheFile = Path.GetFileName(pdfFileName);

                AddContent(document, onlyNameOfTheFile);
                PageXofYFooter(pdfDocument, document, pdfFileName);
            }
            finally
            {
                document.Close();
            }

            return pdfFileName;
        }

        public static IEnumerable<string> CreateFewDocuments(string folder, string documentPrefix,
            uint numberOfDocuments, PageSize? pageSize = null)
        {
            var counter = 0;
            while (counter++ < numberOfDocuments)
            {
                var fileName = Path.Combine(folder, $"{documentPrefix}_{counter}.pdf");
                yield return CreateDocument(fileName, pageSize ?? GetRandomPageSize());
            }
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

                var onlyNameOfTheFile = Path.GetFileName(fileName);
                var paragraph = new Paragraph($"File {onlyNameOfTheFile} / Page {pageId} of {numPages}");
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
