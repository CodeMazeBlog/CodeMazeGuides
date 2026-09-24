namespace CheckPathFileOrDirectoryCSharp
{
    public static class PathExistsUsage
    {
        public static void Run()
        {
            Console.WriteLine("Using Path.Exists:");

            bool anythingHere;
            bool isDirectory;
            bool isFile;

            // file
            var testFile = Path.Combine(Path.GetTempPath(), "test_file5.abc");
            File.WriteAllText(testFile, string.Empty);

            anythingHere = Path.Exists(testFile);
            isDirectory = Directory.Exists(testFile);
            isFile = File.Exists(testFile);

            Console.WriteLine($"{testFile}: anythingHere = {anythingHere}, isDirectory = {isDirectory}, isFile = {isFile}\n");

            // directory
            var testDirectory = Path.Combine(Path.GetTempPath(), "test_directory5");
            Directory.CreateDirectory(testDirectory);

            anythingHere = Path.Exists(testDirectory);
            isDirectory = Directory.Exists(testDirectory);
            isFile = File.Exists(testDirectory);

            Console.WriteLine($"{testDirectory}: anythingHere = {anythingHere}, isDirectory = {isDirectory}, isFile = {isFile}\n");

            // no file or directory
            var notExistingPath = Path.Combine(Path.GetTempPath(), "someNotExistingPath5");

            anythingHere = Path.Exists(notExistingPath);
            isDirectory = Directory.Exists(notExistingPath);
            isFile = File.Exists(notExistingPath);

            Console.WriteLine($"{notExistingPath}: anythingHere = {anythingHere}, isDirectory = {isDirectory}, isFile = {isFile}\n");
        }
    }
}
