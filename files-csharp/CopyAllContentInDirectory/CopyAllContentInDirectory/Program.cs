using System.IO.Abstractions;

namespace CopyAllContentInDirectory;

public static class Program
{
    public static string SourceDir { get; set; } = "";
    public static string DestinationDir { get; set; } = "";
    public static IFileSystem FileSystem { get; set; } = new FileSystem(); // for testing purposes

    public static void Main()
    {
        CopyDirectory(SourceDir, DestinationDir, true);
    }

    public static void CopyDirectory(string sourceDir, string destinationDir, bool overwriteFiles)
    {
        var allDirectories = FileSystem.Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

        foreach (string dir in allDirectories)
        {
            string dirToCreate = FileSystem.Path.Join(destinationDir, FileSystem.Path.GetRelativePath(sourceDir, dir));
            FileSystem.Directory.CreateDirectory(dirToCreate);
        }

        FileSystem.Directory.CreateDirectory(destinationDir);

        var allFiles = FileSystem.Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);

        foreach (string newPath in allFiles)
        {
            string newFile = FileSystem.Path.Join(destinationDir, FileSystem.Path.GetRelativePath(sourceDir, newPath));
            FileSystem.File.Copy(newPath, newFile, overwriteFiles);
        }
    }
}
