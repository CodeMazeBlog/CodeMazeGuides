namespace EqualityVsIsInCSharp
{
    public class File
    {
        public File(string path)
        {
            this.Path = path;
        }

        public string? Path { get; }

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
