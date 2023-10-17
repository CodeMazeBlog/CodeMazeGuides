using iText.Kernel.Pdf;
using iText.Kernel.Utils;

namespace ITextMergingPDFs
{
    public class Merger
    {
        private readonly string _path;

        public Merger(string path)
        {
            _path = path;
        }

        public string MergePDFs(string[] pdfFiles, string mergedPdfFileName)
        {
            var fullFileName = GetFullFileName(mergedPdfFileName);
            MergingMethodWithChecks(pdfFiles, fullFileName);
            return fullFileName;
        }

        public string MergePDFsFirstPage(string[] pdfFiles, string mergedPdfFileName)
        {
            var fullFileName = GetFullFileName(mergedPdfFileName);
            MergeOnlyFirstPagesWithChecks(pdfFiles, fullFileName);
            return fullFileName;
        }

        private string GetFullFileName(string mergedPdfFileName)
        {
            return System.IO.Path.Combine(_path, mergedPdfFileName);
        }

        private static void CheckParameters(string[] pdfFiles, string mergedPdfFileName)
        {
            if (string.IsNullOrWhiteSpace(mergedPdfFileName))
                throw new ArgumentOutOfRangeException(nameof(mergedPdfFileName));

            if (pdfFiles.Any(file => !File.Exists(file)))
                throw new ArgumentOutOfRangeException(nameof(pdfFiles));

            if (pdfFiles.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(pdfFiles));
        }

        private static void SimpleMergingMethod(string[] pdfFiles, string mergedPdfFileName)
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

        private static void MergingMethodWithChecks(string[] pdfFiles, string mergedPdfFileName)
        {
            CheckParameters(pdfFiles, mergedPdfFileName);

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

        private static void MergeOnlyFirstPagesWithChecks(string[] pdfFiles, string mergedPdfFileName)
        {
            CheckParameters(pdfFiles, mergedPdfFileName);

            using var writer = new PdfWriter(mergedPdfFileName);
            using var mergedPdfDocument = new PdfDocument(writer);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            foreach (var file in pdfFiles)
            {
                using var reader = new PdfReader(file);
                using var srcPdfDocument = new PdfDocument(reader);
                pdfMerger.Merge(srcPdfDocument, 1, 1);
            }
        }
    }
}
