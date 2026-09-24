namespace CheckPathFileOrDirectoryCSharp
{
    public static class FileInfoAndDirectoryInfoDrawbacks
    {
        public static void Run()
        {
            Console.WriteLine("FileInfo and DirectoryInfo drawbacks");

            var testFile = Path.Combine(Path.GetTempPath(), "test_file3.abc");
            if (File.Exists(testFile)) File.Delete(testFile);

            var fileInfo = new FileInfo(testFile);

            bool existsFileInfo = fileInfo.Exists;
            bool existsFile = File.Exists(testFile);

            Console.WriteLine($"existsFileInfo = {existsFileInfo}");
            Console.WriteLine($"existsFile = {existsFile}");

            File.WriteAllText(testFile, string.Empty);

            existsFileInfo = fileInfo.Exists;
            existsFile = File.Exists(testFile);

            Console.WriteLine($"existsFileInfo = {existsFileInfo}");
            Console.WriteLine($"existsFile = {existsFile}");

            fileInfo.Refresh();
            existsFileInfo = fileInfo.Exists;

            Console.WriteLine($"existsFileInfo after Refresh() = {existsFileInfo}\n");
        }

    }
}
