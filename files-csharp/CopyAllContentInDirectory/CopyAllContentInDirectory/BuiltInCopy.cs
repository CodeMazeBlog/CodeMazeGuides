using Microsoft.VisualBasic.FileIO;

namespace CopyAllContentInDirectory;

public static class BuiltInCopy
{
    public static void CopyWithVisualBasic(string sourcePath, string destinationPath)
    {
        FileSystem.CopyDirectory(sourcePath, destinationPath, overwrite: true);
    }
}
