using System.IO.Compression;

namespace ZipFilesInNet
{
    public class CreateZipFiles
    {
        public void CreateZipFromFolderUsingFunction(string zipFileName, string sourceFolder) =>
            ZipFile.CreateFromDirectory(sourceFolder, zipFileName);

        public void CreateZipFromFolderUsingAlgorithm(
            string zipFileName, string sourceFolder,
            CompressionLevel compressionLevel = CompressionLevel.Optimal,
            string filePattern = "*.*")
        {
            // get the list of all the files under the current folder
            var folder = new DirectoryInfo(sourceFolder);
            FileInfo[] files = folder.GetFiles(filePattern, SearchOption.AllDirectories);

            // create an empty zip file
            using var archive = ZipFile.Open(zipFileName, ZipArchiveMode.Create);

            // loop through each file and add it as an entry into a zip file
            foreach (var file in files)
            {
                // NOTE: we have to store relative folder information in a zip file
                archive.CreateEntryFromFile(
                    file.FullName,
                    Path.GetRelativePath(folder.FullName, file.FullName),
                    compressionLevel
                );
            }
        }

        public void CreateHelloWorldZipFile(string zipFileName)
        {
            var helloText = "Hello world!";

            // opening a new ZIP file
            using var archive = ZipFile.Open(zipFileName, ZipArchiveMode.Create);

            // creating an empty entry with a defined name
            var entry = archive.CreateEntry("hello.txt");

            // using stream to add text to newly created entry
            using (var st = entry.Open())
            using (var writerManifest = new StreamWriter(st))
                writerManifest.WriteLine(helloText);
        }
    }
}
