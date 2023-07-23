using System.IO.Compression;

namespace ZipFilesInNet
{
    public class ReadZipFiles
    {
        public void ListAllFilesInZipUsingName(string zipFileName) =>
          ExecuteList(zipFileName, (entry) => entry.Name);

        public void ListAllFilesInZipUsingFullName(string zipFileName) =>
          ExecuteList(zipFileName, (entry) => entry.FullName);

        public void ExtractAllFilesToFolderUsingFunction(string zipFileName, string destinationFolder) =>
            ZipFile.ExtractToDirectory(zipFileName, destinationFolder, true);

        public void ExtractAllFilesToFolderUsingAlgorithm(string zipFileName, string destinationFolder)
        {
            using var zipFile = ZipFile.OpenRead(zipFileName);
            var rootFolder = destinationFolder;
            foreach (var entry in zipFile.Entries)
            {
                // combine the root folder with a folder in the zip file 
                var wholePath = Path.Combine(
                    rootFolder,
                    Path.GetDirectoryName(entry.FullName) ?? string.Empty);

                // if the folder does not exist, create one
                if (!Directory.Exists(wholePath))
                    Directory.CreateDirectory(wholePath);

                // create a file only if it is a file and not a folder
                if (!string.IsNullOrEmpty(entry.Name))
                {
                    var wholeFileName = Path.Combine(
                        wholePath,
                        Path.GetFileName(entry.FullName));

                    // override file if it already exists
                    entry.ExtractToFile(wholeFileName, true);
                }
            }
        }

        public void DisplayBase64StringsOfFilesInArchive(string zipFileName)
        {
            using var zipFile = ZipFile.OpenRead(zipFileName);
            foreach (var entry in zipFile.Entries)
            {
                // calculate base64 only if it is a file and not a folder
                if (!string.IsNullOrEmpty(entry.Name))
                {
                    using (var stream = entry.Open())
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        var bytes = memoryStream.ToArray();
                        var base64 = Convert.ToBase64String(bytes);
                        Console.WriteLine($"{entry.FullName} => {base64}");
                    }
                }
            }
        }

        private void ExecuteList(string zipFileName, Func<ZipArchiveEntry, string> element)
        {
            int counter = 0;

            using var zipFile = ZipFile.OpenRead(zipFileName);
            foreach (var entry in zipFile.Entries)
            {
                Console.WriteLine($"{++counter,3}: {element(entry)}");
            }
        }
    }
}
