UseFileAndDirectory();

UseFileInfoAndDirectoryInfo();

TestFileInfoAndDirectoryInfoDrawbacks();

UseFileAttributes();


static void UseFileAndDirectory()
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

static void UseFileInfoAndDirectoryInfo()
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

static void TestFileInfoAndDirectoryInfoDrawbacks()
{
    Console.WriteLine("FileInfo and DirectoryInfo drawbacks");

    var testFile = Path.Combine(Path.GetTempPath(), "test_file3.abc");
    if (File.Exists(testFile)) File.Delete(testFile);

    var fileInfo = new FileInfo(testFile);

    bool existsFileInfo = fileInfo.Exists;
    bool existsFile = File.Exists(testFile);

    Console.WriteLine($"existsFileInfo = {existsFileInfo}");
    Console.WriteLine($"existsFile = {existsFile}");

    File.CreateText(testFile);

    existsFileInfo = fileInfo.Exists;
    existsFile = File.Exists(testFile);

    Console.WriteLine($"existsFileInfo = {existsFileInfo}");
    Console.WriteLine($"existsFile = {existsFile}\n");
}


static void UseFileAttributes()
{
    Console.WriteLine("Using FileAttributes");

    bool isFile;
    bool isDirectory;

    // file
    var testFile = Path.Combine(Path.GetTempPath(), "test_file4.abc");
    File.CreateText(testFile);

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
    var notExistingPath = "someNotExistingPath4";

    try
    {
        attributes = File.GetAttributes(notExistingPath);
        isDirectory = attributes.HasFlag(FileAttributes.Directory);
        isFile = !isDirectory;
    }
    catch (FileNotFoundException)
    {
        isFile = isDirectory = false;
    }
    Console.WriteLine($"{notExistingPath}: isFile = {isFile}, isDirectory = {isDirectory}\n");
}
