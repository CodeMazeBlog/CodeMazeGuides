using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Reflection;
using System.Text;

namespace ITextBasics
{
    public static class BigDocument
    {
        private static readonly string loremIpsumText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private static readonly string[] loremIpsumWords = loremIpsumText.Split(' ');

        public static void Create(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument);

            string? executablePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
            string imageFile = Path.Combine(executablePath!, "Resources", "Flower.jpg");

            for (int i = 0; i < 3; i++)
            {
                document.Add(CreateHeader1(LoremIpsum(3)));
                document.Add(CreateHeader2(LoremIpsum(7)));
                document.Add(CreateNormalParagraph(LoremIpsum(100)));

                document.Add(CreateHeader2(LoremIpsum(7)));
                document.Add(CreateNormalParagraph(LoremIpsum(55)));
                document.Add(CreateNormalParagraph(LoremIpsum(27)));

                document.Add(CreateHeader1(LoremIpsum(6)));
                document.Add(CreateHeader2(LoremIpsum(3)));
                document.Add(CreateNormalParagraph(LoremIpsum(50)));
                document.Add(CreatePictureParagraph(imageFile));
                document.Add(CreateHeader2(LoremIpsum(3)));
                document.Add(CreateNormalParagraph(LoremIpsum(45)));
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

        private static Paragraph CreatePictureParagraph(string imageFile)
        {
            var imageData = ImageDataFactory.Create(imageFile);
            var image = new Image(imageData);

            return new Paragraph()
                .Add(image);
        }

        private static string LoremIpsum(int numberOfWords)
        {
            StringBuilder sb = new(numberOfWords * 10);
            while (numberOfWords > 0)
            {
                int wordsToTake = Math.Min(numberOfWords, loremIpsumWords.Length);
                _ = sb.AppendJoin(' ', loremIpsumWords.Take(wordsToTake));
                numberOfWords -= wordsToTake;
            }

            return sb.ToString();
        }
    }
}
