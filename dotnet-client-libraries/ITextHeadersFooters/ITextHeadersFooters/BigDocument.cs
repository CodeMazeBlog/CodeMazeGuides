using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ITextHeadersFooters.PdfCreatorManager;
using System.Text;

namespace ITextHeadersFooters
{
    public static class BigDocument
    {
        private static readonly string loremIpsumText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private static readonly string[] loremIpsumWords = loremIpsumText.Split(' ');

        public static void CreateBasicDocument(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, PageSize.A4);

            AddContent(document);
        }

        public static void CreateBasicDocumentWithBigMargins(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, PageSize.A4);

            document.SetMargins(
                topMargin: UnitConverter.mm2uu(100), bottomMargin: UnitConverter.mm2uu(100),
                rightMargin: UnitConverter.mm2uu(60), leftMargin: UnitConverter.mm2uu(60));

            AddContent(document);
        }

        public static void AddTextAfterPageWasGenerated(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, PageSize.A4, immediateFlush: false);

            try
            {
                AddContent(document);

                var paragraph = new Paragraph("This text was added after page was generated");
                document.ShowTextAligned(p: paragraph,
                    x: UnitConverter.mm2uu(50), y: UnitConverter.mm2uu(10), pageNumber: 1,
                    textAlign: TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
            }
            finally
            {
                document.Close();
            }
        }

        public static void UsageOfShowTextAlignedMethod(string pdfFileName)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, PageSize.A4);

            var textAlignments = new TextAlignment[] { TextAlignment.LEFT, TextAlignment.CENTER, TextAlignment.RIGHT };
            var verticalAlignments = new VerticalAlignment[] { VerticalAlignment.BOTTOM, VerticalAlignment.MIDDLE, 
                VerticalAlignment.TOP };

            var page = pdfDocument.AddNewPage();
            var canvas = new PdfCanvas(page);

            float stepLeft = UnitConverter.mm2uu(70);
            float stepDown = UnitConverter.mm2uu(10);

            float left = UnitConverter.mm2uu(30);
            foreach (var textAlignment in textAlignments)
            {
                float top = UnitConverter.mm2uu(270);
                foreach (var verticalAlignment in verticalAlignments)
                {
                    canvas.SetStrokeColor(ColorConstants.RED);
                    canvas.Circle(x: left, y: top, r: UnitConverter.mm2uu(0.7f));
                    canvas.Stroke();

                    canvas.SetStrokeColor(ColorConstants.BLACK);

                    var text = new Paragraph($"{textAlignment} / {verticalAlignment}");
                    document.ShowTextAligned(text, left, top, 1, textAlignment, verticalAlignment, 0.3f);

                    top -= stepDown;
                }

                left += stepLeft;
            }
        }

        public static void HeaderFooterExample1(string pdfFileName)
        {
            CreateBaseDocumentAndAddHeaderFooter(pdfFileName, PageXofYFooter);
        }

        public static void HeaderFooterExample2(string pdfFileName)
        {
            CreateBaseDocumentAndAddHeaderFooter(pdfFileName, PageNumberInHeaderDateInFooter);
        }

        public static void HeaderFooterExample3(string pdfFileName)
        {
            CreateBaseDocumentAndAddHeaderFooter(pdfFileName, DrawLine);
        }

        public static void HeaderFooterExample4(string pdfFileName)
        {
            CreateBaseDocumentAndAddHeaderFooter(pdfFileName, DifferentLeftAndRightPage);
        }

        private static void CreateBaseDocumentAndAddHeaderFooter(string pdfFileName, 
            Action<PdfDocument, Document> headerFooter)
        {
            using var writer = new PdfWriter(pdfFileName);
            using var pdfDocument = new PdfDocument(writer);
            using var document = new Document(pdfDocument, PageSize.A4, immediateFlush: false);

            try
            {
                AddContent(document);

                headerFooter(pdfDocument, document);
            }
            finally
            {
                document.Close();
            }
        }

        private static void PageXofYFooter(PdfDocument pdfDocument, Document document)
        {
            var numPages = pdfDocument.GetNumberOfPages();
            for (int pageId = 1; pageId <= numPages; pageId++)
            {
                var page = pdfDocument.GetPage(pageId);
                var centerPage = page.GetPageSize().GetWidth() / 2;

                var paragraph = new Paragraph($"Page {pageId} of {numPages}");
                document.ShowTextAligned(paragraph, centerPage, UnitConverter.mm2uu(10), pageId, 
                    TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
            }
        }

        private static void PageNumberInHeaderDateInFooter(PdfDocument pdfDocument, Document document)
        {
            var numPages = pdfDocument.GetNumberOfPages();
            for (int pageId = 1; pageId <= numPages; pageId++)
            {
                var page = pdfDocument.GetPage(pageId);
                var rightMarginPosition = page.GetPageSize().GetWidth() - document.GetRightMargin();
                var headerPosition = page.GetPageSize().GetHeight() - UnitConverter.mm2uu(10);

                var header = new Paragraph($"Page {pageId} of {numPages}");
                document.ShowTextAligned(header, rightMarginPosition, headerPosition, pageId, 
                    TextAlignment.RIGHT, VerticalAlignment.MIDDLE, 0);

                var leftMarginPosition = document.GetLeftMargin();

                var footer = new Paragraph($"Printed on {DateTime.Today.ToLongDateString()}");
                document.ShowTextAligned(footer, leftMarginPosition, UnitConverter.mm2uu(10), pageId, 
                    TextAlignment.LEFT, VerticalAlignment.MIDDLE, 0);
            }
        }

        private static void DrawLine(PdfDocument pdfDocument, Document document)
        {
            var numPages = pdfDocument.GetNumberOfPages();
            for (int pageId = 1; pageId <= numPages; pageId++)
            {
                var page = pdfDocument.GetPage(pageId);
                var rightMarginPosition = page.GetPageSize().GetWidth() - document.GetRightMargin();
                var topMarginPosition = page.GetPageSize().GetHeight() - document.GetTopMargin();
                var spaceGap = UnitConverter.mm2uu(2);

                var canvas = new PdfCanvas(page);
                canvas.SetStrokeColor(ColorConstants.BLACK);
                canvas.SetLineWidth(1);
                canvas.MoveTo(document.GetLeftMargin(), topMarginPosition);
                canvas.LineTo(rightMarginPosition, topMarginPosition);
                canvas.MoveTo(document.GetLeftMargin(), document.GetBottomMargin());
                canvas.LineTo(rightMarginPosition, document.GetBottomMargin());
                canvas.Stroke();

                var header = new Paragraph($"Page {pageId} of {numPages}");
                document.ShowTextAligned(header, rightMarginPosition, topMarginPosition + spaceGap, pageId, 
                    TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);

                var leftMarginPosition = document.GetLeftMargin();

                var footer = new Paragraph($"Printed on {DateTime.Today.ToLongDateString()}");
                document.ShowTextAligned(footer, leftMarginPosition, document.GetBottomMargin() - spaceGap, pageId, 
                    TextAlignment.LEFT, VerticalAlignment.TOP, 0);
            }
        }

        private static void DifferentLeftAndRightPage(PdfDocument pdfDocument, Document document)
        {
            var numPages = pdfDocument.GetNumberOfPages();
            for (int pageId = 1; pageId <= numPages; pageId++)
            {
                var page = pdfDocument.GetPage(pageId);
                var rightMarginPosition = page.GetPageSize().GetWidth() - document.GetRightMargin();

                var header = new Paragraph($"{pageId}");
                if (pageId % 2 == 0)
                {
                    document.ShowTextAligned(header, document.GetLeftMargin(), document.GetBottomMargin(), pageId, 
                        TextAlignment.LEFT, VerticalAlignment.MIDDLE, 0);
                }
                else
                {
                    document.ShowTextAligned(header, rightMarginPosition, document.GetBottomMargin(), pageId, 
                        TextAlignment.RIGHT, VerticalAlignment.MIDDLE, 0);
                }
            }
        }

        private static void AddContent(Document document, int numberOfRepetitions = 3)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
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

        private static string LoremIpsum(int numberOfWords)
        {
            StringBuilder sb = new(numberOfWords * 10);
            while (numberOfWords > 0)
            {
                int wordsToTake = Math.Min(numberOfWords, loremIpsumWords.Length);
                sb.AppendJoin(' ', loremIpsumWords.Take(wordsToTake));
                numberOfWords -= wordsToTake;
            }

            return sb.ToString();
        }
    }
}
