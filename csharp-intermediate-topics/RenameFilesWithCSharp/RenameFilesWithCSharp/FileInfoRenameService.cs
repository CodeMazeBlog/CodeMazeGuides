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
        var oldFile = @"C:\MyDirectory\File2.txt";
        var newFile = @"C:\MyDirectory\File_v2.txt";

        RenameFileWithFileInfoClass(oldFile, newFile);
    }
}
