using System.Reflection;
using System.Text;

public class Program
{
    public static void Main()
    {
        string fileName = "CodeMaze.txt";

        try
        {
            string fileContent = ReadFileUsingDirectory(fileName);
            Console.WriteLine("File content:\n" + fileContent);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }

    public static string ReadFileUsingDirectory(string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, fileName);

        return File.ReadAllText(filePath);
    }

    public static string ReadFileUsingAppDomain(string fileName)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectory, fileName);

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
