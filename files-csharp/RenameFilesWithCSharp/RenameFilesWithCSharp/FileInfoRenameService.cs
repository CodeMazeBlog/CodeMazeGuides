namespace RenameFilesWithCSharp;
public static class FileInfoRenameService
{
    public static void RenameFileWithFileInfoClass(string oldFile, string newFile)
    {
        var file = new FileInfo(oldFile);

        file.MoveTo(newFile);
    }

    public static void ExecuteRenameFileWithFileInfoClass()
    {
        var directoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(directoryPath);

        var oldFile = Path.Combine(directoryPath, "File2.txt");
        File.Create(oldFile).Dispose();

        var newFile = Path.Combine(directoryPath, "File_v2.txt");

        RenameFileWithFileInfoClass(oldFile, newFile);

        Console.WriteLine($"Renamed {Path.GetFileName(oldFile)} to {Path.GetFileName(newFile)}");

        Directory.Delete(directoryPath, true);
    }
}