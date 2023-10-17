namespace ITextMergingPDFs
{
    public class FolderManager
    {
        public string PdfFolderName { get; }

        private FolderManager(string folder, string subfolder)
        {
            PdfFolderName = Path.Combine(folder, subfolder);
            EnsurePFDDocumentsFolderExists();
        }

        public static FolderManager CreateFolderManagerInTemporaryFolder(string subFolderName)
        {
            return new FolderManager(Path.GetTempPath(), subFolderName);
        }

        public static FolderManager CreateFolderManagerAsProgramSubfolder(string subFolderName)
        {
            return new FolderManager(Path.GetDirectoryName(Environment.ProcessPath)!, subFolderName);
        }

        public void EnsurePFDDocumentsFolderExists(bool deleteFolderIfExists = false)
        {
            if (!Directory.Exists(PdfFolderName))
                Directory.CreateDirectory(PdfFolderName);
        }

        public void RecreatePFDDocumentsFolder()
        {
            if (Directory.Exists(PdfFolderName))
            {
                DeletePDFDocumentsFolder();
                Directory.CreateDirectory(PdfFolderName);
            }
        }

        public void DeletePDFDocumentsFolder()
        {
            if (Directory.Exists(PdfFolderName))
                Directory.Delete(PdfFolderName, true);
        }
    }
}
