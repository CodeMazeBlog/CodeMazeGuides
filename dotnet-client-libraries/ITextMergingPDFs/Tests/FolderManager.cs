namespace Tests
{
    internal class FolderManager
    {
        public string PdfFolderName { get; }

        private FolderManager(string folder, string subfolder)
        {
            PdfFolderName = Path.Combine(folder, subfolder);

            if (!Directory.Exists(PdfFolderName))
                Directory.CreateDirectory(PdfFolderName);
        }

        public static FolderManager CreateFolderManagerInTemporaryFolder(string subFolderName)
        {
            return new FolderManager(Path.GetTempPath(), subFolderName);
        }

        public string GetFullName(string fileName)
        {
            return Path.Combine(PdfFolderName, fileName);
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
