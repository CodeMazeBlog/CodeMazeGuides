using System.IO.Abstractions;

namespace CopyAllContentInDirectory
{
    public static class Program
    {
        public static string SourceDir { get; set; } = "";
        public static string DestinationDir { get; set; } = "";
        public static IFileSystem FileSystem { get; set; } = new FileSystem(); // for testing purposes

        public static void Main()
        {
            foreach (string dir in FileSystem.Directory.GetDirectories(SourceDir, "*", SearchOption.AllDirectories))
            {
                string dirToCreate = dir.Replace(SourceDir, DestinationDir);
                FileSystem.Directory.CreateDirectory(dirToCreate);
            }

            foreach (string newPath in FileSystem.Directory.GetFiles(SourceDir, "*.*", SearchOption.AllDirectories))
            {
                FileSystem.File.Copy(newPath, newPath.Replace(SourceDir, DestinationDir), true);
            }
        }
    }
}