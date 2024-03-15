using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ITextAddTextToPDFs
{
    public static class BasicTextAdder
    {
        public static void Add(string inputFile, string outputFile, string textToAdd)
        {
            using var writer = new PdfWriter(outputFile);
            using var outputDocument = new PdfDocument(writer);

            using var reader = new PdfReader(inputFile);
            using var inputDocument = new PdfDocument(reader);

            using var workingDocument = new Document(outputDocument);

            var numberOfPages = inputDocument.GetNumberOfPages();
            for (var i = 1; i <= numberOfPages; i++)
            {
                var page = inputDocument.GetPage(i);

                var newPage = page.CopyTo(outputDocument);
                outputDocument.AddPage(newPage);

                var copyText = new Paragraph(textToAdd);
                workingDocument.ShowTextAligned(
                    p: copyText,
                    x: UnitConverter.mm2uu(10), y: UnitConverter.mm2uu(10),
                    pageNumber: i,
                    textAlign: TextAlignment.LEFT, vertAlign: VerticalAlignment.TOP,
                    radAngle: 0);
            }
        }
    }
}
