namespace CheckPathFileOrDirectoryCSharp
{
    public static class FileAndDirectoryUsage
    {
        public static void Run()
        {
            Console.WriteLine("Using File and Directory:");

            bool isFile;
            bool isDirectory;

            // file
            var testFile = Path.Combine(Path.GetTempPath(), "test_file1.abc");
            File.CreateText(testFile);

            isFile = File.Exists(testFile);
            isDirectory = Directory.Exists(testFile);

            Console.WriteLine($"{testFile}: isFile = {isFile}, isDirectory = {isDirectory}\n");

            // directory
            var testDirectory = Path.Combine(Path.GetTempPath(), "test_directory1");
            Directory.CreateDirectory(testDirectory);

            isFile = File.Exists(testDirectory);
            isDirectory = Directory.Exists(testDirectory);

            Console.WriteLine($"{testDirectory}: isFile = {isFile}, isDirectory = {isDirectory}\n");

            // no file or directory
            var notExistingPath = "someNotExistingPath1";

            isFile = File.Exists(notExistingPath);
            isDirectory = Directory.Exists(notExistingPath);

            Console.WriteLine($"{notExistingPath}: isFile = {isFile}, isDirectory = {isDirectory}\n");
        }
    }
}
