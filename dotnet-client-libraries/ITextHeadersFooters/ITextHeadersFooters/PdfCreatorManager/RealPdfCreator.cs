using ITextHeadersFooters.ConsoleManager;
using System.Diagnostics;

namespace ITextHeadersFooters.PdfCreatorManager
{
    public class RealPdfCreator : IPdfCreator
    {
        private readonly IConsole _console;

        public RealPdfCreator(IConsole console)
        {
            _console = console;
        }

        public string EnsurePFDDocumentsFolderExists()
        {
            string executablePath = Path.GetDirectoryName(Environment.ProcessPath)!;

            var pdfFolder = Path.Combine(executablePath, "PFDDocuments");
            if (!Directory.Exists(pdfFolder))
                Directory.CreateDirectory(pdfFolder);

            return pdfFolder;
        }

        public string CreatePDFFileName(string pdfFolder, string pdfFilePrefix)
        {
            return Path.Combine(pdfFolder, $"{pdfFilePrefix}_{Guid.NewGuid()}.pdf");
        }

        public void DisplayPDFFile(string pdfFileName)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(pdfFileName)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                }
            };

            process.Start();
        }

        public void CreatePDFFile(string pdfFilePrefix, Action<string> pdfCreateAction)
        {
            _console.Clear();
            var pdfFolder = EnsurePFDDocumentsFolderExists();
            var pdfFileName = CreatePDFFileName(pdfFolder, pdfFilePrefix);

            _console.WriteLine($"\n Creating PDF file '{pdfFileName}'");
            pdfCreateAction(pdfFileName);

            _console.WriteLine($"\n PDF file '{pdfFileName}' created");
            DisplayPDFFile(pdfFileName);

            _console.WriteLine($"\n Displaying PDF file '{pdfFileName}'");
        }
    }
}
