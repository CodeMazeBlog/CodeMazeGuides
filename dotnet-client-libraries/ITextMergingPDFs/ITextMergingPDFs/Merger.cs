using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout;

namespace ITextMergingPDFs
{
    public class Merger
    {
        private readonly string _path;

        private enum CopyPages
        {
            AllPages,
            FirstPage,
            OddPages,
            EvenPages
        }

        public static Merger Create(string path)
        {
            return new Merger(path);
        }

        private Merger(string path)
        {
            _path = path;
        }

        public string MergePDFs(string[] pdfFiles, string mergedPdfFileName) =>
            DoMerging(pdfFiles, mergedPdfFileName, CopyPages.AllPages);

        public string MergePDFsFirstPage(string[] pdfFiles, string mergedPdfFileName) =>
            DoMerging(pdfFiles, mergedPdfFileName, CopyPages.FirstPage);

        public string[] SplitDocument(string pdfFile)
        {
            var oddPages = DoMerging(new string[] { pdfFile }, GetFullFileName("odd.pdf"), CopyPages.OddPages);
            var evenPages = DoMerging(new string[] { pdfFile }, GetFullFileName("even.pdf"), CopyPages.EvenPages);

            return new string[] { oddPages, evenPages };
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

        private string DoMerging(string[] pdfFiles, string mergedPdfFileName, CopyPages copyPages)
        {
            CheckParameters(pdfFiles, mergedPdfFileName);
            string fullFileName = GetFullFileName(mergedPdfFileName);

            using var writer = new PdfWriter(fullFileName);
            using var mergedPdfDocument = new PdfDocument(writer);

            var pdfMerger = new PdfMerger(mergedPdfDocument);
            foreach (string file in pdfFiles)
            {
                using var reader = new PdfReader(file);
                using var srcPdfDocument = new PdfDocument(reader);
                switch (copyPages)
                {
                    case CopyPages.AllPages:
                        pdfMerger.Merge(srcPdfDocument, 1, srcPdfDocument.GetNumberOfPages());
                        break;
                    case CopyPages.FirstPage:
                        pdfMerger.Merge(srcPdfDocument, 1, 1);
                        break;
                    case CopyPages.OddPages:
                        int[] oddArray = Enumerable.Range(1, srcPdfDocument.GetNumberOfPages()).Where(x => x % 2 != 0).ToArray();
                        pdfMerger.Merge(srcPdfDocument, oddArray);
                        break;
                    case CopyPages.EvenPages:
                        int[] evenArray = Enumerable.Range(1, srcPdfDocument.GetNumberOfPages()).Where(x => x % 2 == 0).ToArray();
                        pdfMerger.Merge(srcPdfDocument, evenArray);
                        break;
                    default:
                        break;
                }
            }

            return fullFileName;
        }
    }
}
