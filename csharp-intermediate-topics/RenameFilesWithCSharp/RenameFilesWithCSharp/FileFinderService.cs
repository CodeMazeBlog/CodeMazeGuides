namespace RenameFilesWithCSharp;

public static class FileFinderService
{
    public static List<string> FindFilesInFolder(string directoryPath)
    {
        return Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories)
            .ToList();
    }

    public static void ExecuteFindFilesInFolder()
    {
        var directoryPath = @"C:\MyDirectory";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        for (var i = 1; i < 5; i++)
        {
            var filePath = $@"{directoryPath}\File{i}.txt";

            File.Create(filePath).Close();
        }

        var filesInFolder = FindFilesInFolder(directoryPath);

        foreach (var file in filesInFolder)
        {
            var fileName = Path.GetFileName(file);

            Console.WriteLine(fileName);
        }
    }
}