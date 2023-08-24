namespace EqualityVsIsInCSharp
{
    public class File
    {
        public string Path { get; }

        public File(string path)
        {
            Path = path;
        }

        public static bool operator == (File file1, File file2)
        {
            return file1.Path == file2.Path;
        }

        public static bool operator != (File file1, File file2)
        {
            return file1.Path != file2.Path;
        }
    }
}
