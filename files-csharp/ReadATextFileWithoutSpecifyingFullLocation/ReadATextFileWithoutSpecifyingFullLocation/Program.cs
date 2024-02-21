using System.Reflection;
using System.Text;

public class Program
{
    public static void Main()
    {
        string fileName = @"C:\Code Maze\files-csharp\ReadATextFileWithoutSpecifyingFullLocation\CodeMaze.txt";

        try
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fileContent = ReadFileUsingDirectory(currentDirectory, fileName);
            Console.WriteLine("File content:\n" + fileContent);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }

    public static string ReadFileUsingDirectory(string currentDirectoryPath, string fileName)
    {
        string filePath = Path.Combine(currentDirectoryPath, fileName);

        return File.ReadAllText(filePath);
    }

    public static string ReadEmbeddedFile(string fileName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(name => name.EndsWith(fileName, StringComparison.Ordinal));

        using Stream stream = assembly.GetManifestResourceStream(resourceName) ??
            throw new FileNotFoundException("Embedded resource not found after matching.", resourceName);

        using StreamReader reader = new(stream, Encoding.UTF8);

        return reader.ReadToEnd();
    }
}
