namespace ITextMergingPDFs
{
    public class FolderManager
    {
        private readonly string _pdfFolderName;

        private FolderManager(string folder, string subfolder)
        {
            _pdfFolderName = Path.Combine(folder, subfolder);
        }

        public static FolderManager CreateFolderManagerInTemporaryFolder(string subFolderName)
        {
            return new FolderManager(Path.GetTempPath(), subFolderName);
        }

        public static FolderManager CreateFolderManagerAsProgramSubfolder(string subFolderName)
        {
            return new FolderManager(Path.GetDirectoryName(Environment.ProcessPath)!, subFolderName);
        }

        public string EnsurePFDDocumentsFolderExists(bool deleteFolderIfExists = false)
        {
            if (deleteFolderIfExists && Directory.Exists(_pdfFolderName))
                DeletePFDDocumentsFolder();

            if (!Directory.Exists(_pdfFolderName))
                Directory.CreateDirectory(_pdfFolderName);

            return _pdfFolderName;
        }

        public void DeletePFDDocumentsFolder()
        {
            if (Directory.Exists(_pdfFolderName))
                Directory.Delete(_pdfFolderName, true);
        }
    }
}
