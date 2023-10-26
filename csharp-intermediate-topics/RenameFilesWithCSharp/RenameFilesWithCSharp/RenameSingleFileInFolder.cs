namespace RenameFilesWithCSharp;

public class RenameSingleFileInFolder
{
    public static void RenameFileInDirectory(string oldFile, string newFile)
    {
        // Renames the old file to the new file.
        File.Move(oldFile, newFile);
    }

    public static void ExecuteRenameFileInDirectory()
    {
        var oldFile = @"C:\MyDirectory\FileOne.txt";

        var newFile = @"C:\MyDirectory\FileOne.txt";


        RenameFileInDirectory(oldFile, newFile);
    }
}
