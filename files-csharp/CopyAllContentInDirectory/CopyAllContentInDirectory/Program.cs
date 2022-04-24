using System.IO.Abstractions;

namespace CopyAllContentInDirectory
{
    public static class Program
    {
        public static string sourceDir { get; set; } = "";
        public static string destinationDir { get; set; } = "";
        public static IFileSystem fileSystem { get; set; } = new FileSystem(); // for testing purposes

        public static void Main()
        {
            foreach (string dir in fileSystem.Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                string dirToCreate = dir.Replace(sourceDir, destinationDir);
                fileSystem.Directory.CreateDirectory(dirToCreate);
            }

            foreach (string newPath in fileSystem.Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                fileSystem.File.Copy(newPath, newPath.Replace(sourceDir, destinationDir), true);
            }
        }
    }
}