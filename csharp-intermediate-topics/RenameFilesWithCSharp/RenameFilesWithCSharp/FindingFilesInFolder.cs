namespace RenameFilesWithCSharp;

public class FindingFilesInFolder
{
    public static List<string> FindFilesInFolder(string directoryPath)
    {
        return Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories)
            .ToList();
    }

    public static void ExecuteFindFilesInFolder()
    {
        var directoryPath = @"C:\MyDirectory";

        var filesInFolder = FindFilesInFolder(directoryPath);

        foreach (var file in filesInFolder)
        {
            var fileName = Path.GetFileName(file);

            Console.WriteLine(fileName);
        }
    }
}