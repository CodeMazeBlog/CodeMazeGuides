using System.Globalization;
namespace IdisposableObjects;

public class Program
{
    protected static private string? basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
    protected static private string? projectsPath = Directory.GetParent(basePath).Parent.Parent.Parent.FullName;
    protected static private string exampleFilePath = projectsPath + "/codeMazeExample.txt";
    protected static private StreamReader? exampleFileReader;
    protected static private  StreamWriter? exampleFileWriter;

    public static void Main()
    {
        if (!File.Exists(exampleFilePath))
        {
            using StreamWriter? exampleFileWriter = new(exampleFilePath, append: true);
            exampleFileWriter.WriteLine("example File Content");
            exampleFileWriter.Close();
        }
        //Console.WriteLine(UnmanagedObjectFileManager());
        //Console.WriteLine(UsingusingFileManager());
        Console.WriteLine(UsingTryFinallyFileManager());
    }

    public static int UnmanagedObjectFileManager()
    {
        exampleFileReader = new StreamReader(exampleFilePath);
        var exampleFileContents = exampleFileReader.ReadToEnd();
        var exampleFileReaderInfo = new StringInfo(exampleFileContents);

        return exampleFileReaderInfo.LengthInTextElements;
    }

    public static int UsingusingFileManager()
    {
        using StreamReader? exampleFileReader = new(exampleFilePath);
        var exampleFileContents = exampleFileReader.ReadToEnd();
        var exampleFileReaderInfo = new StringInfo(exampleFileContents);

        return exampleFileReaderInfo.LengthInTextElements;
    }

    public static int UsingTryFinallyFileManager()
    {
        int exampleFileReaderInfoLenth = 0;
        try
        {
            exampleFileReader = new(exampleFilePath);
            var exampleFileContents = exampleFileReader.ReadToEnd();
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
            exampleFileWriter?.Dispose();
        }

        return exampleFileReaderInfoLenth;
    }
}