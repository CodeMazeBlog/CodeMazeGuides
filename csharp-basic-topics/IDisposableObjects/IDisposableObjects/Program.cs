using System.Globalization;
namespace IdisposableObjects;

public class Program
{
    protected static string basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
    protected static string projectsPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(basePath).FullName).FullName).FullName).FullName;
    protected static string exampleFilePath = projectsPath + "/codeMazeExample.txt";

    protected static StreamReader ExampleFileReader = null;
    protected static StreamWriter ExampleFileWriter = null;

    public static void Main()
    {
        if (!File.Exists(exampleFilePath))
        {
            using StreamWriter ExampleFileWriter = new StreamWriter(exampleFilePath, append: true);
            ExampleFileWriter.WriteLine("example File Content");
            ExampleFileWriter.Close();
        }

        Console.WriteLine(UnmanagedObjectFileManager());
        //Console.WriteLine(UsingusingFileManager());
        //Console.WriteLine(UsingTryFinallyFileManager());

    }
    public static int UnmanagedObjectFileManager()
    {

        ExampleFileReader = new StreamReader(exampleFilePath);

        var ExampleFileContents = ExampleFileReader.ReadToEnd();

        var ExampleFileReaderInfo = new StringInfo(ExampleFileContents);

        return ExampleFileReaderInfo.LengthInTextElements;
    }

    public static int UsingusingFileManager()
    {
        using StreamReader ExampleFileReader = new StreamReader(exampleFilePath);

        var ExampleFileContents = ExampleFileReader.ReadToEnd();

        var ExampleFileReaderInfo = new StringInfo(ExampleFileContents);

        return ExampleFileReaderInfo.LengthInTextElements;
    }



    public static int UsingTryFinallyFileManager()
    {
        int ExampleFileReaderInfoLenth = 0;
        try
        {

            ExampleFileReader = new StreamReader(exampleFilePath);

            var ExampleFileContents = ExampleFileReader.ReadToEnd();

            ExampleFileReaderInfoLenth = new StringInfo(ExampleFileContents).LengthInTextElements;
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
            ExampleFileReader?.Dispose();
            ExampleFileWriter?.Dispose();

        }
        return ExampleFileReaderInfoLenth;
    }

}
