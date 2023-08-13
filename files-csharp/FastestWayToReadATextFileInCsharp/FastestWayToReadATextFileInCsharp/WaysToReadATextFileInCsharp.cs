using System.Text;

namespace FastestWayToReadATextFileInCsharp
{
    public class WaysToReadATextFileInCsharp
    {
        private readonly string _sampleFilePath;

        public WaysToReadATextFileInCsharp(string sampleFilePath)
        {
            _sampleFilePath = sampleFilePath;
        }

        public string UseFileReadAllLines()
        {
            var stringArray = File.ReadAllLines(_sampleFilePath);

            return string.Join(Environment.NewLine, stringArray);
        }

        public string UseFileReadAllText() => File.ReadAllText(_sampleFilePath);
        
        public string UseFileReadLines()
        {
            var stringArray = File.ReadLines(_sampleFilePath);

            return string.Join(Environment.NewLine, stringArray);
        }

        public string UseStreamReaderReadLine()
        {
            using var streamReader = new StreamReader(_sampleFilePath);
            var stringBuilder = new StringBuilder();
            string fileLine;

            while ((fileLine = streamReader.ReadLine()) != null)
            {
                stringBuilder.AppendLine(fileLine);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string UseStreamReaderReadToEnd()
        {
            using var streamReader = new StreamReader(_sampleFilePath);

            return streamReader.ReadToEnd();
        }

        public string UseStreamReaderReadBlock()
        {
            using var streamReader = new StreamReader(_sampleFilePath);
            var buffer = new char[1024];
            int numberRead;
            var stringBuilder = new StringBuilder();

            while ((numberRead = streamReader.ReadBlock(buffer, 0, buffer.Length)) > 0)
            {
                stringBuilder.Append(buffer, 0, numberRead);
            }

            return stringBuilder.ToString();
        }

        public string UseBufferedStreamObject()
        {
            var stringBuilder = new StringBuilder();

            using (var fileStream = new FileStream(_sampleFilePath, FileMode.Open))
            using (var bufferedStream = new BufferedStream(fileStream))
            using (var streamReader = new StreamReader(bufferedStream))
            {
                string fileLine;

                while ((fileLine = streamReader.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(fileLine);
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}