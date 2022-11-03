using System.Globalization;
namespace IdisposableObjects;

public class Program
{
    private protected static  string? basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
    private protected static  string? projectsPath = Directory.GetParent(basePath).Parent.Parent.Parent.FullName;
    private protected static string exampleFilePath = projectsPath + "/codeMazeExample.txt";
    private protected StreamReader? exampleFileReader;

    public Program(StreamReader? exampleFileReader=null)
    {
        this.exampleFileReader = exampleFileReader;
    }

    public static void Main()
    {
        Program newProgramInstance = new();
        if (!File.Exists(exampleFilePath))
        {
            using StreamWriter? exampleFileWriter = new(exampleFilePath, append: true);
            exampleFileWriter.WriteLine("example File Content");
            exampleFileWriter.Close();
        }
        //Console.WriteLine(newProgramInstance.UnmanagedObjectFileManager());
        //Console.WriteLine(newProgramInstance.UsingusingFileManager());
        Console.WriteLine(newProgramInstance.UsingTryFinallyFileManager());
    }

    public  int UnmanagedObjectFileManager()
    {
        exampleFileReader = new StreamReader(exampleFilePath);
        string? exampleFileContents = exampleFileReader.ReadToEnd();
        StringInfo? exampleFileReaderInfo = new(exampleFileContents);

        return exampleFileReaderInfo.LengthInTextElements;
    }

    public int UsingusingFileManager()
    {
        using StreamReader? exampleFileReader = new(exampleFilePath);
        string? exampleFileContents = exampleFileReader.ReadToEnd();
        StringInfo? exampleFileReaderInfo = new(exampleFileContents);

        return exampleFileReaderInfo.LengthInTextElements;
    }

    public int UsingTryFinallyFileManager()
    {
        int exampleFileReaderInfoLenth = 0;
        try
        {
            exampleFileReader = new(exampleFilePath);
            string? exampleFileContents = exampleFileReader.ReadToEnd();
            exampleFileReaderInfoLenth = new StringInfo(exampleFileContents).LengthInTextElements;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file cannot be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error has occurred.");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("There is insufficient memory to read the file.");
        }
        finally
        {
            exampleFileReader?.Dispose();
        }

        return exampleFileReaderInfoLenth;
    }
}