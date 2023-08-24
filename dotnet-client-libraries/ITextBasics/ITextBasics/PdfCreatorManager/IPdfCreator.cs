namespace ITextBasics.PdfCreatorManager
{
    public interface IPdfCreator
    {
        string EnsurePFDDocumentsFolderExists();

        string CreatePDFFileName(string pdfFolder, string pdfFilePrefix);

        void DisplayPDFFile(string pdfFileName);

        void CreatePDFFile(string pdfFilePrefix, Action<string> pdfCreateAction);
    }
}