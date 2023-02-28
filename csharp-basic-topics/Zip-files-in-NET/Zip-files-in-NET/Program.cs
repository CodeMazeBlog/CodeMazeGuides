using System.IO.Compression;
using Zip_files_in_NET;

var reading = new ReadZipFiles();
var writing = new CreateZipFiles();
var modify = new ModifyZipFiles();

string zipFile = "multi-folder.zip";

caption($"List all files in {zipFile} using only Name property");
reading.ListAllFilesInZipUsingName(zipFile);

wait();

caption($"List all files in {zipFile} using FName property");
reading.ListAllFilesInZipUsingFullName(zipFile);

wait();

var subfolder = "extracted-files";
caption($"Extracting {zipFile} to subfolder {subfolder}",
         "Open Explorer and check extracted files");
reading.ExtractAllFilesToFolderUsingFunction(zipFile, subfolder);

wait();

zipFile = "single-file.zip";
caption($"Calculating Base64 string from files in {zipFile}");
reading.DisplayBase64StringsOfFilesInArchive(zipFile);

wait();

zipFile = "new-zip-file.zip";
File.Delete(zipFile);
var folder = "extracted-files";
caption($"Creating {zipFile} from all the files in {folder} subfolder", 
        $"Open Explorer and check that {zipFile} was created");
writing.CreateZipFromFolderUsingFunction(zipFile, folder);

wait();

zipFile = "new-zip-file-with-png.zip";
File.Delete(zipFile);
var fileMask = "*.png";
caption($"Creating {zipFile} from all the {fileMask} files in {folder} subfolder", 
        $"Open Explorer and check that {zipFile} was created and contains only zip files");
writing.CreateZipFromFolderUsingAlgorithm(zipFile, folder, CompressionLevel.Optimal, fileMask);

wait();

zipFile = "hello-world.zip";
File.Delete(zipFile);
caption($"Creating {zipFile} zip file on the fly", 
        $"Open Explorer and check that {zipFile} was created and contains only one file");
writing.CreateHelloWorldZipFile(zipFile);

wait();

zipFile = "multi-folder-without-png.zip";
fileMask = "*.png";
File.Delete(zipFile);
File.Copy("multi-folder.zip", zipFile);
caption($"Deleting all {fileMask} files from {zipFile}", 
        $"Open Explorer and check that {zipFile}contains no {fileMask} files");
modify.DeleteFilesFromZipFile(zipFile, fileMask);

wait();

void wait()
{
    Console.WriteLine("\nPress a key to continue...");
    Console.ReadKey();
    Console.Clear();
}

void caption(string caption, string? subCaption = null)
{
    int size = Console.WindowWidth;
    Console.WriteLine(new string('*', size));
    Console.WriteLine($"  ** {caption}");
    if (subCaption != null)
        Console.WriteLine($"\n    ** {subCaption}");
    Console.WriteLine(new string('*', size));
    Console.WriteLine("\n\n");
}
