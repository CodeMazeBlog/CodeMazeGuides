using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;

namespace ITextMergingPDFs
{
    public class Resizer
    {
        private readonly string _path;

        public static Resizer Create(string path)
        {
            return new Resizer(path);
        }

        private Resizer(string path)
        {
            _path = path;
        }

        public string ResizeFromA4ToA5(string inputPdfDocument, string outputPdfDocument)
        {
            string fullFileName = GetFullFileName(outputPdfDocument);
            using var writer = new PdfWriter(fullFileName);
            using var outputDocument = new PdfDocument(writer);
            outputDocument.SetDefaultPageSize(PageSize.A5);

            using var reader = new PdfReader(inputPdfDocument);
            using var inputDocument = new PdfDocument(reader);

            for (int i = 1; i <= inputDocument.GetNumberOfPages(); i++)
            {
                PdfPage page = inputDocument.GetPage(i);

                var formXObject = page.CopyAsFormXObject(outputDocument);
                var pdfCanvas = new PdfCanvas(outputDocument.AddNewPage());
                pdfCanvas.AddXObjectFittedIntoRectangle(formXObject, new Rectangle(0, 0, PageSize.A5.GetWidth(), PageSize.A5.GetHeight()));
            }

            return fullFileName;
        }

        private string GetFullFileName(string mergedPdfFileName)
        {
            return System.IO.Path.Combine(_path, mergedPdfFileName);
        }
    }
}
