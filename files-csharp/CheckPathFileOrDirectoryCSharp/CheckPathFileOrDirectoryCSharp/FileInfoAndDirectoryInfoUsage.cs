namespace CheckPathFileOrDirectoryCSharp
{
    public class FileInfoAndDirectoryInfoUsage
    {
        public static void Run()
        {
            Console.WriteLine("Using FileInfo and DirectoryInfo:");

            bool isFile;
            bool isDirectory;

            FileInfo fileInfo;
            DirectoryInfo directoryInfo;

            // file
            var testFile = Path.Combine(Path.GetTempPath(), "test_file2.abc");
            File.CreateText(testFile);

            fileInfo = new FileInfo(testFile);
            directoryInfo = new DirectoryInfo(testFile);

            isFile = fileInfo.Exists;
            isDirectory = fileInfo.Exists;

            Console.WriteLine($"{testFile}: isFile = {isFile}, isDirectory = {isDirectory}\n");

            // directory
            var testDirectory = Path.Combine(Path.GetTempPath(), "test_directory2");
            Directory.CreateDirectory(testDirectory);

            fileInfo = new FileInfo(testDirectory);
            directoryInfo = new DirectoryInfo(testDirectory);

            isFile = fileInfo.Exists;
            isDirectory = fileInfo.Exists;

            Console.WriteLine($"{testDirectory}: isFile = {isFile}, isDirectory = {isDirectory}\n");

            // no file or directory
            var notExistingPath = "someNotExistingPath2";

            fileInfo = new FileInfo(notExistingPath);
            directoryInfo = new DirectoryInfo(notExistingPath);

            isFile = fileInfo.Exists;
            isDirectory = fileInfo.Exists;

            Console.WriteLine($"{notExistingPath}: isFile = {isFile}, isDirectory = {isDirectory}\n");
        }

    }
}
