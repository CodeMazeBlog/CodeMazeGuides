namespace RenameFilesWithCSharp;

public class FindingFilesInFolder
{
    public static List<string> FindFilesInFolder(string directoryPath)
    {

        var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

        return files.ToList();
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
