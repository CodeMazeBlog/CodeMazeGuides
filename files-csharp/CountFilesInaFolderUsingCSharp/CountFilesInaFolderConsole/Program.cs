// See https://aka.ms/new-console-template for more information
using CountFilesInaFolderLibrary.AdvancedApproach.UsingLINQWithDirectoryEnumerateFiles;
using CountFilesInaFolderLibrary.AdvancedApproach.UsingWinAPI;
using CountFilesInaFolderLibrary.BasicApproach;

var tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
Directory.CreateDirectory(tempDirectory);

for (var i = 0; i < 1000; i++)
{
    File.Create(Path.Combine(tempDirectory, $"file{i}.txt")).Dispose();
}

Console.WriteLine($"File count using CountFilesUsingGetFiles method: {FileCounterUsingGetFiles.CountFilesUsingGetFiles(tempDirectory)}");
Console.WriteLine();

Console.WriteLine($"File count using CountFilesUsingLINQEnumerateFiles method: {FileCounterUsingLINQ.CountFilesUsingLINQEnumerateFiles(tempDirectory)}");
Console.WriteLine();

#if WINDOWS
Console.WriteLine($"File count using CountFilesUsingWinAPI method: {FileCounterUsingWinAPI.CountFilesUsingWinAPI(tempDirectory)}");
Console.WriteLine();
#endif

if (Directory.Exists(tempDirectory))
    Directory.Delete(tempDirectory, true);