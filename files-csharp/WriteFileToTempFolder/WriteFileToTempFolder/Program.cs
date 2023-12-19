namespace WriteFileToTempFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tempFile = System.IO.Path.GetTempFileName();
            TempFileCreator.CreateTempFile(tempFile);

            var tempFileContent = File.ReadAllText(tempFile);
            Console.WriteLine(tempFileContent);

            tempFile = System.IO.Path.GetTempPath() + "text.txt";
            TempFileCreator.CreateTempFile(tempFile);

            tempFileContent = File.ReadAllText(tempFile);
            Console.WriteLine(tempFileContent);

            tempFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\text.txt";
            TempFileCreator.CreateTempFile(tempFile);

            tempFileContent = File.ReadAllText(tempFile);
            Console.WriteLine(tempFileContent);
        }
    }
}