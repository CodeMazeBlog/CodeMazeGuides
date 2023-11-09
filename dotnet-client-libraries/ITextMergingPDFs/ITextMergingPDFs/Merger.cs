using iText.Kernel.Pdf;
using iText.Kernel.Utils;

namespace ITextMergingPDFs
{
    public static class Merger
    {
        private static void CheckParameters(string[] pdfFiles, string mergedPdfFileName)
        {
            if (string.IsNullOrWhiteSpace(mergedPdfFileName))
                throw new ArgumentOutOfRangeException(nameof(mergedPdfFileName));

            if (pdfFiles.Any(file => !File.Exists(file)))
                throw new ArgumentOutOfRangeException(nameof(pdfFiles));

            if (pdfFiles.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(pdfFiles));
        }

        public static void Merge(string[] documents, string mergedDocument)
        {
            CheckParameters(documents, mergedDocument);

            using var writer = new PdfWriter(mergedDocument);
            using var mergedPdfDocument = new PdfDocument(writer);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            foreach (var file in documents)
            {
                using var reader = new PdfReader(file);
                using var srcPdfDocument = new PdfDocument(reader);
                pdfMerger.Merge(srcPdfDocument, 1, srcPdfDocument.GetNumberOfPages());
            }
        }

        public static void SimpleMerge(string[] pdfFiles, string mergedPdfFileName)
        {
            using var writer = new PdfWriter(mergedPdfFileName);
            using var mergedPdfDocument = new PdfDocument(writer);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            foreach (var file in pdfFiles)
            {
                using var reader = new PdfReader(file);
                using var srcPdfDocument = new PdfDocument(reader);
                pdfMerger.Merge(srcPdfDocument, 1, srcPdfDocument.GetNumberOfPages());
            }
        }
    }
}
