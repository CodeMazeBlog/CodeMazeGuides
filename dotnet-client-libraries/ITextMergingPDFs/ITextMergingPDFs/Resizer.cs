using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;

namespace ITextMergingPDFs
{
    public static class Resizer
    {
        public static void ResizeToA5(string inputPdfDocument, string outputPdfDocument)
        {
            using var writer = new PdfWriter(outputPdfDocument);
            using var outputDocument = new PdfDocument(writer);
            outputDocument.SetDefaultPageSize(PageSize.A5);

            using var reader = new PdfReader(inputPdfDocument);
            using var inputDocument = new PdfDocument(reader);

            var (a5PageWidth, a5PageHeight) = (PageSize.A5.GetWidth(), PageSize.A5.GetHeight());
            for (var i = 1; i <= inputDocument.GetNumberOfPages(); i++)
            {
                var page = inputDocument.GetPage(i);

                if (page.GetPageSize() == PageSize.A5)
                {
                    outputDocument.AddPage(page);
                }
                else
                {
                    var formXObject = page.CopyAsFormXObject(outputDocument);
                    var pdfCanvas = new PdfCanvas(outputDocument.AddNewPage());
                    pdfCanvas.AddXObjectFittedIntoRectangle(formXObject, new Rectangle(0, 0, a5PageWidth, a5PageHeight));
                }
            }
        }
    }
}
