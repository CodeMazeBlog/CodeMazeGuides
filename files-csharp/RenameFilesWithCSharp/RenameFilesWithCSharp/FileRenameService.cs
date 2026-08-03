namespace RenameFilesWithCSharp;
public static class FileRenameService
{
    public static void RenameFileWithFileClass(string oldFile, string newFile)
    {
        File.Move(oldFile, newFile);
    }

    public static void ExecuteRenameFileWithFileClass()
    {
        var directoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(directoryPath);

        var oldFile = Path.Combine(directoryPath, "File1.txt");
        File.Create(oldFile).Dispose();

        var newFile = Path.Combine(directoryPath, "File_v1.txt");

        RenameFileWithFileClass(oldFile, newFile);

        Console.WriteLine($"Renamed {Path.GetFileName(oldFile)} to {Path.GetFileName(newFile)}");

        Directory.Delete(directoryPath, true);
    }
}