namespace CheckPathFileOrDirectoryCSharp
{
    public static class FileAttributesUsage
    {
        public static void Run()
        {
            Console.WriteLine("Using FileAttributes");

            bool isFile;
            bool isDirectory;

            // file
            var testFile = Path.Combine(Path.GetTempPath(), "test_file4.abc");
            File.WriteAllText(testFile, string.Empty);

            var attributes = File.GetAttributes(testFile);

            isDirectory = attributes.HasFlag(FileAttributes.Directory);
            isFile = !isDirectory;

            Console.WriteLine($"{testFile}: isFile = {isFile}, isDirectory = {isDirectory}\n");

            // directory
            var testDirectory = Path.Combine(Path.GetTempPath(), "test_directory4");
            Directory.CreateDirectory(testDirectory);

            attributes = File.GetAttributes(testDirectory);

            isDirectory = attributes.HasFlag(FileAttributes.Directory);
            isFile = !isDirectory;

            Console.WriteLine($"{testDirectory}: isFile = {isFile}, isDirectory = {isDirectory}\n");

            // no file or directory
            var notExistingPath = Path.Combine(Path.GetTempPath(), "someNotExistingPath4");

            isDirectory = false;
            isFile = false;

            if (Path.Exists(notExistingPath))
            {
                attributes = File.GetAttributes(notExistingPath);

                isDirectory = attributes.HasFlag(FileAttributes.Directory);
                isFile = !isDirectory;
            }

            Console.WriteLine($"{notExistingPath}: isFile = {isFile}, isDirectory = {isDirectory}\n");
        }
    }
}
