using System.Globalization;
namespace IDisposableObjects
{
    public class FileManager
    {
        readonly string _exampleFilePath;
        public FileManager()
        {
            _exampleFilePath = $"{Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).Parent.Parent.Parent.FullName}/codeMazeExample.txt";
            if (!File.Exists(_exampleFilePath))
            {
                using StreamWriter? exampleFileWriter = new(_exampleFilePath, append: true);
                exampleFileWriter.WriteLine("example File Content");
                exampleFileWriter.Close();
            }
        }

        public int UnmanagedObjectFileManager()
        {
            StreamReader?  exampleFileReader = new(_exampleFilePath);
            string? exampleFileContents = exampleFileReader.ReadToEnd();
            StringInfo? exampleFileReaderInfo = new(exampleFileContents);

            return exampleFileReaderInfo.LengthInTextElements;
        }

        public int UsingFileManager()
        {
            using StreamReader? exampleFileReader = new(_exampleFilePath);
            string? exampleFileContents = exampleFileReader.ReadToEnd();
            StringInfo? exampleFileReaderInfo = new(exampleFileContents);

            return exampleFileReaderInfo.LengthInTextElements;
        }

        public int TryFinallyFileManager()
        {
            int exampleFileReaderInfoLength = 0;
            StreamReader? exampleFileReader = null;
            try
            {
                exampleFileReader = new(_exampleFilePath);
                string? exampleFileContents = exampleFileReader.ReadToEnd();
                exampleFileReaderInfoLength = new StringInfo(exampleFileContents).LengthInTextElements;
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

            return exampleFileReaderInfoLength;
        }

    }
}
