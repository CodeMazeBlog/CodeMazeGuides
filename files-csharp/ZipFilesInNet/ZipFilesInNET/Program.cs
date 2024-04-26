using System.IO.Compression;
using ZipFilesInNet;

var read = new ReadZipFiles();
var write = new CreateZipFiles();
var modify = new ModifyZipFiles();

string zipFile = "multi-folder.zip";

Caption($"List all files in {zipFile} using only Name property");
read.ListAllFilesInZipUsingName(zipFile);

Wait();

Caption($"List all files in {zipFile} using FName property");
read.ListAllFilesInZipUsingFullName(zipFile);

Wait();

var subfolder = "extracted-files";
Caption($"Extracting {zipFile} to subfolder {subfolder}",
         "Open Explorer and check extracted files");
read.ExtractAllFilesToFolderUsingFunction(zipFile, subfolder);

Wait();

zipFile = "single-file.zip";
Caption($"Calculating Base64 string from files in {zipFile}");
read.DisplayBase64StringsOfFilesInArchive(zipFile);

Wait();

zipFile = "new-zip-file.zip";
File.Delete(zipFile);
var folder = "extracted-files";
Caption($"Creating {zipFile} from all the files in {folder} subfolder",
        $"Open Explorer and check that {zipFile} was created");
write.CreateZipFromFolderUsingFunction(zipFile, folder);

Wait();

zipFile = "new-zip-file-with-png.zip";
File.Delete(zipFile);
var fileMask = "*.png";
Caption($"Creating {zipFile} from all the {fileMask} files in {folder} subfolder",
        $"Open Explorer and check that {zipFile} was created and contains only zip files");
write.CreateZipFromFolderUsingAlgorithm(zipFile, folder, CompressionLevel.Optimal, fileMask);

Wait();

zipFile = "hello-world.zip";
File.Delete(zipFile);
Caption($"Creating {zipFile} zip file on the fly",
        $"Open Explorer and check that {zipFile} was created and contains only one file");
write.CreateHelloWorldZipFile(zipFile);

Wait();

zipFile = "multi-folder-without-png.zip";
fileMask = "*.png";
File.Delete(zipFile);
File.Copy("multi-folder.zip", zipFile);
Caption($"Deleting all {fileMask} files from {zipFile}",
        $"Open Explorer and check that {zipFile}contains no {fileMask} files");
modify.DeleteFilesFromZipFile(zipFile, fileMask);

Wait();

void Wait()
{
    Console.WriteLine("\nPress a key to continue...");
    Console.ReadKey();
    Console.Clear();
}

void Caption(string caption, string? subCaption = null)
{
    var size = Console.WindowWidth;
    Console.WriteLine(new string('*', size));
    Console.WriteLine($"  ** {caption}");
    if (subCaption != null)
        Console.WriteLine($"\n    ** {subCaption}");
    Console.WriteLine(new string('*', size));
    Console.WriteLine("\n\n");
}
