namespace GetNumberOfLinesInTextFile
{
    public class FileHelper
    {
        public static int CountLinesUsingReadAllLinesMethod(string fileName)
        {
            var numberOfLines = File.ReadAllLines(fileName).Length;

            return numberOfLines;
        }

        public static int CountLinesUsingStreamReader(string fileName)
        {
            var lineCount = 0;
            using StreamReader reader = new(fileName);

            while (reader.ReadLine() != null)
            {
                lineCount++;
            }

            return lineCount;
        }

        public static int CountLinesUsingReadLinesMethod(string fileName)
        {
            IEnumerable<string> lines = File.ReadLines(fileName);

            return lines.Count();
        }
    }
}
