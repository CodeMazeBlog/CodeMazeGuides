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

        public void DeletePDFDocumentsFolder()
        {
            if (Directory.Exists(PdfFolderName))
                Directory.Delete(PdfFolderName, true);
        }

        public string CopyFile(string sourceFileNameFullName, string destinationFileName)
        {
            var destinationFile = Path.Combine(PdfFolderName, destinationFileName);
            File.Copy(sourceFileNameFullName, destinationFile);
            return destinationFile;
        }

        public int CountFiles()
        {
            return Directory.GetFiles(PdfFolderName).Length;
        }
    }
}
