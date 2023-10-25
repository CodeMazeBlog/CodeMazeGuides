using System.Diagnostics;

namespace RenameFilesWithCSharp
{
    public class RenameSingleFileInFolder
    {
        public static void RenameFileInDirectory()
        {
            // The path to the old file to be renamed.
            var oldFile = @"C:\Users\HP\Desktop\MyDirectory\FileOne.txt";

            // The path to the new file to be renamed to.
            var newFile = @"C:\Users\HP\Desktop\MyDirectory\File_v1.txt";

            // Renames the old file to the new file.
            File.Move(oldFile, newFile);
        }
    }
}
