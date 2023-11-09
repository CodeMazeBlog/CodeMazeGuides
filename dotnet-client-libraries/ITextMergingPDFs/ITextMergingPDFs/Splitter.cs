using iText.Kernel.Pdf;
using iText.Kernel.Utils;

namespace ITextMergingPDFs
{
    public static class Splitter
    {
        public static (string oddPages, string evenPages) Split(string sourcePdfFile)
        {
            using var reader = new PdfReader(sourcePdfFile);
            using var srcPdfDocument = new PdfDocument(reader);

            var sourceFilePath = Path.GetDirectoryName(sourcePdfFile)!;

            var oddPagesFileName = Path.Combine(sourceFilePath, "odd.pdf");
            ExtractPagesThatMatchCriteria(srcPdfDocument, oddPagesFileName,
                pageNum => pageNum % 2 != 0);

            var evenPagesFileName = Path.Combine(sourceFilePath, "even.pdf");
            ExtractPagesThatMatchCriteria(srcPdfDocument, evenPagesFileName,
                pageNum => pageNum % 2 == 0);

            return (oddPagesFileName, evenPagesFileName);
        }

        private static void ExtractPagesThatMatchCriteria(PdfDocument srcPdfDocument,
            string resultPdfDocument, Func<int, bool> pageSelectionCriteria)
        {
            using var writer = new PdfWriter(resultPdfDocument);
            using var writerDocument = new PdfDocument(writer);

            var selectedPages = Enumerable
                .Range(1, srcPdfDocument.GetNumberOfPages())
                .Where(pageSelectionCriteria)
                .ToArray();

            var merger = new PdfMerger(writerDocument);
            merger.Merge(srcPdfDocument, selectedPages);
        }
    }
}
