namespace DirectoryAndDirectoryInfo
{
    public class DirectoryMethods
    {
        public static DirectoryInfo CreateADirectory(string path)
        {
            var newDirectory = Directory.CreateDirectory(path);
            return newDirectory;
        }

        public static void DeleteEmptyDirectory(string path)
        {
            Directory.Delete(path);
        }

        public static void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }

        public static string[] GetDirectories(string path)
        {
            var directories = Directory.GetDirectories(path);
            return directories;
        }

        public static string[] GetFilesInDirectory(string path)
        {
            var files = Directory.GetFiles(path);
            return files;
        }
    }
}
