namespace RenameFilesWithCSharp;

public static class FileRenameService
{
    public static void RenameFileWithFileClass(string oldFile, string newFile)
    {
        File.Move(oldFile, newFile);
    }

    public static void ExecuteRenameFileWithFileClass()
    {
        var oldFile = @"C:\MyDirectory\File1.txt";
        var newFile = @"C:\MyDirectory\File_v1.txt";

        RenameFileWithFileClass(oldFile, newFile);
    }
}
