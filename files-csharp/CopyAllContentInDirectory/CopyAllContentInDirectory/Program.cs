using System.IO.Abstractions;

namespace CopyAllContentInDirectory
{
    public class Program
    {
        public static string sourceDir { get; set; } = "";
        public static string destDir { get; set; } = "";

        public static void Main(IFileSystem fs)
        {
            foreach (string dir in fs.Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                string dirToCreate = dir.Replace(sourceDir, destDir);
                fs.Directory.CreateDirectory(dirToCreate);
            }

            foreach (string newPath in fs.Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                fs.File.Copy(newPath, newPath.Replace(sourceDir, destDir), true);
            }
        }
    }
}