namespace GetNumberOfLinesInTextFile
{
    public class FileHelper
    {
        public static int CountLinesUsingReadAllLinesMethod(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File not found: {fileName}");
            }

            var numberOfLines = File.ReadAllLines(fileName).Length;

            return numberOfLines;
        }

        public static int CountLinesUsingStreamReader(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File not found: {fileName}");
            }

            var lineCount = 0;
            using StreamReader reader = new(fileName);

            while (reader.ReadLine() is not null)
            {
                lineCount++;
            }

            return lineCount;
        }

        public static int CountLinesUsingReadLinesMethod(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File not found: {fileName}");
            }

            IEnumerable<string> lines = File.ReadLines(fileName);

            return lines.Count();
        }
    }
}
