using System.Diagnostics;

namespace RenameFilesWithCSharp
{
    public class RenameSingleFileInFolder
    {
        public static void RenameFileInDirectory(string oldFile, string newFile)
        {
            // Renames the old file to the new file.
            File.Move(oldFile, newFile);
        }
    }
}
