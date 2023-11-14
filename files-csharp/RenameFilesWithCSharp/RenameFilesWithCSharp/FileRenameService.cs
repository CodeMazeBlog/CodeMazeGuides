namespace RenameFilesWithCSharp;

public static class FileRenameService
{
    public static void RenameFileWithFileClass(string oldFile, string newFile)
    {
        File.Move(oldFile, newFile);
    }

    public static void ExecuteRenameFileWithFileClass()
    {
        var directoryPath = Path.Combine(Path.GetTempPath(), "MyDirectory");

        var oldFile = Path.Combine(directoryPath, "File1.txt");
        var newFile = Path.Combine(directoryPath, "File_v1.txt");

        RenameFileWithFileClass(oldFile, newFile);
    }
}
