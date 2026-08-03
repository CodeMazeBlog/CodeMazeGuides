namespace RenameFilesWithCSharp;
public static class FileFinderService
{
    public static IEnumerable<string> FindFilesInFolder(string directoryPath)
    {
        return Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories);
    }

    public static void ExecuteFindFilesInFolder()
    {
        var directoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); 
        Directory.CreateDirectory(directoryPath);

        for (var i = 1; i < 5; i++) 
        { 
            var filePath = Path.Combine(directoryPath, $"File{i}.txt");
            File.Create(filePath).Dispose();
        }

        var filesInFolder = FindFilesInFolder(directoryPath);

        foreach (var file in filesInFolder)
        { 
            var fileName = Path.GetFileName(file); 
            Console.WriteLine(fileName); 
        }

        Directory.Delete(directoryPath, true);
    }
}