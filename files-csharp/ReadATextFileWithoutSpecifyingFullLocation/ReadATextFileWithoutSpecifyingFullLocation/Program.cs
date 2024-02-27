public class Program
{
    public static void Main()
    {
        string fileName = @"CodeMaze.txt";

        try
        {
            var fileContent = ReadFile(fileName);
            Console.WriteLine("File content:\n" + fileContent);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }
    public static string ReadFileUsingCurrentDirectory(string fileName)
    {
        string currentDirectoryPath = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectoryPath, fileName);

        return ReadFile(filePath);
    }

    public static string ReadFileUsingBaseDirectory(string fileName)
    {
        string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectoryPath, fileName);

        return ReadFile(filePath);
    }

    public static string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }  
}
