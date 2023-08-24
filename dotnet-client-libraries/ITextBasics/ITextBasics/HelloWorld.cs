using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Diagnostics;
using System.Reflection;

namespace ITextBasics
{
    public static class HelloWorld
    {
        public static void CreateBasicPDF(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument);

            var message = "Hello World";
            var para = new Paragraph(message);
            document.Add(para);
        }

        public static void CreateAdvancedHeaderPDF(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument);

            var message = "Hello World";
            var para = new Paragraph(message)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(50)
                .SetBold()
                .SetBorder(new SolidBorder(4));

            document.Add(para);
        }

        public static void CreateAdvancedMoreParagraphsPDF(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument);

            var message = "Hello World";
            int numberOfLines = 130;
            for (int i = 0; i < numberOfLines; i++)
            {
                var para = new Paragraph($"{i + 1,-3}: {message}");
                document.Add(para);
            }
        }

        public static void CreatePDFWithImage(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument);

            string? executablePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
            string imageFile = Path.Combine(executablePath!, "Resources", "Flower.jpg");

            var imageData = ImageDataFactory.Create(imageFile);
            var image = new Image(imageData);
            document.Add(image);

            var message = "Hello World";
            var para = new Paragraph(message);
            document.Add(para);
        }
    }
}
