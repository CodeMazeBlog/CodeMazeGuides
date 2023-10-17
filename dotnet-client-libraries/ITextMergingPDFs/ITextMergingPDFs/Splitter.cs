using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System.Linq;

namespace ITextMergingPDFs
{
    public class Splitter
    {
        public static (string oddPages, string evenPages) Split(string sourcePdfFile)
        {
            using var reader = new PdfReader(sourcePdfFile);
            using var srcPdfDocument = new PdfDocument(reader);

            var oddPagesFileName = Path.Combine(Path.GetDirectoryName(sourcePdfFile)!, "odd.pdf");
            newMethod(srcPdfDocument, oddPagesFileName, pageNum => pageNum % 2 != 0);

            var evenPagesFileName = Path.Combine(Path.GetDirectoryName(sourcePdfFile)!, "even.pdf");
            newMethod(srcPdfDocument, evenPagesFileName, pageNum => pageNum % 2 == 0);

            return (oddPagesFileName, evenPagesFileName);
        }

        private static void newMethod(PdfDocument srcPdfDocument, string resultPdfDocument,
            Func<int, bool> pageSelection)
        {
            using var writer = new PdfWriter(resultPdfDocument);
            using var writerDocument = new PdfDocument(writer);

            int[] oddPagesArray = Enumerable
                .Range(1, srcPdfDocument.GetNumberOfPages())
                .Where(pageSelection)
                .ToArray();

            var merger = new PdfMerger(writerDocument);
            merger.Merge(srcPdfDocument, oddPagesArray);
        }
    }
}
