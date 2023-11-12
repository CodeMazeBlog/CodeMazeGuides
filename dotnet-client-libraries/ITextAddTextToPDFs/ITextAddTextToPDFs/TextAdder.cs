using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ITextAddTextToPDFs
{
    public class TextAdder
    {
        public string InputFile { get; }
        public string OutputFile { get; }

        public TextAdder(string inputFile, string outputFile)
        {
            InputFile = inputFile;
            OutputFile = outputFile;
        }

        public void Add(string textToAdd)
        {
            using var outputDocument = new PdfDocument(new PdfReader(InputFile), new PdfWriter(OutputFile));
            using var workingDocument = new Document(outputDocument);

            var numberOfPages = outputDocument.GetNumberOfPages();
            for (var i = 1; i <= numberOfPages; i++)
            {
                var copyText = new Paragraph(textToAdd);
                workingDocument.ShowTextAligned(
                    p: copyText,
                    x: UnitConverter.mm2uu(10), y: UnitConverter.mm2uu(10),
                    pageNumber: i,
                    textAlign: TextAlignment.LEFT, vertAlign: VerticalAlignment.TOP,
                    radAngle: 0);
            }
        }

        public void AddCenterText(string textToAdd, int fontSize, float angle, Color color)
        {
            using var outputDocument = new PdfDocument(new PdfReader(InputFile), new PdfWriter(OutputFile));
            using var workingDocument = new Document(outputDocument);

            var numberOfPages = outputDocument.GetNumberOfPages();
            for (var i = 1; i <= numberOfPages; i++)
            {
                var page = outputDocument.GetPage(i);
                var pageSize = page.GetPageSize();
                var (pageWidth, pageHeight) = (pageSize.GetWidth(), pageSize.GetHeight());

                var copyText = new Paragraph(textToAdd)
                    .SetFontSize(fontSize)
                    .SetFontColor(color);

                workingDocument.ShowTextAligned(
                    p: copyText,
                    x: pageWidth / 2, y: pageHeight / 2,
                    pageNumber: i,
                    textAlign: TextAlignment.CENTER, vertAlign: VerticalAlignment.MIDDLE,
                    radAngle: angle);
            }
        }

        public void AddWaterMark(string textToAdd, int fontSize, float angle, Color color)
        {
            using var outputDocument = new PdfDocument(new PdfReader(InputFile), new PdfWriter(OutputFile));
            using var workingDocument = new Document(outputDocument);

            var numberOfPages = outputDocument.GetNumberOfPages();
            for (var i = 1; i <= numberOfPages; i++)
            {
                var page = outputDocument.GetPage(i);
                var pageSize = page.GetPageSize();
                var (pageWidth, pageHeight) = (pageSize.GetWidth(), pageSize.GetHeight());

                var paragraph = new Paragraph(textToAdd)
                        .SetFontSize(fontSize)
                        .SetFontColor(color);

                var under = new PdfCanvas(page.NewContentStreamBefore(), new PdfResources(), outputDocument);
                using var _ = new Canvas(under, page.GetPageSize())
                    .ShowTextAligned(
                        p: paragraph,
                        x: pageWidth / 2, y: pageHeight / 2,
                        pageNumber: i,
                        textAlign: TextAlignment.CENTER, vertAlign: VerticalAlignment.MIDDLE,
                        radAngle: angle);
            }
        }

        public void AddHeaders()
        {
            using var outputDocument = new PdfDocument(new PdfReader(InputFile), new PdfWriter(OutputFile));
            using var workingDocument = new Document(outputDocument);
            var documentName = Path.GetFileName(OutputFile);

            var numberOfPages = outputDocument.GetNumberOfPages();
            for (var i = 1; i <= numberOfPages; i++)
            {
                var page = outputDocument.GetPage(i);
                var pageSize = page.GetPageSize();
                var (pageWidth, pageHeight) = (pageSize.GetWidth(), pageSize.GetHeight());

                var topRow = pageHeight - UnitConverter.mm2uu(7);
                var rightMargin = pageWidth - UnitConverter.mm2uu(10);
                var centerOfPage = pageWidth / 2;

                var caption = new Paragraph(documentName);
                workingDocument.ShowTextAligned(caption, centerOfPage, topRow, i,
                    TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                var pageNumber = new Paragraph($"Page {i} of {numberOfPages}");
                workingDocument.ShowTextAligned(pageNumber, rightMargin, topRow, i,
                    TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            }
        }
    }
}
