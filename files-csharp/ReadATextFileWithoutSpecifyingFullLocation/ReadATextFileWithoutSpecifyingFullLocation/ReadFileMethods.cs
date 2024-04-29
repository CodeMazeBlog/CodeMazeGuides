namespace ReadATextFileWithoutSpecifyingFullLocation;

public static class ReadFileMethods
{
    public static string ReadFileUsingCurrentDirectory(string fileName)
    {
        var currentDirectoryPath = Directory.GetCurrentDirectory();
        var filePath = Path.Combine(currentDirectoryPath, fileName);

        return ReadFile(filePath);
    }

    public static string ReadFileUsingBaseDirectory(string fileName)
    {
        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(baseDirectoryPath, fileName);

        return ReadFile(filePath);
    }

    public static string ReadFile(string filePath) => File.ReadAllText(filePath);
}