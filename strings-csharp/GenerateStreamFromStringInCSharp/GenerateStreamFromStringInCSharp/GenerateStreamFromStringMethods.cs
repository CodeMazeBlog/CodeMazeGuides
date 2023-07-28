using System.Text;

namespace GenerateStreamFromStringInCSharp
{
    public static class GenerateStreamFromStringMethods
    {
        public static Stream
        UseMemoryStreamAndStreamWriter(string sampleString, Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;

            var stream = new MemoryStream(encoding.GetByteCount(sampleString));
            var writer = new StreamWriter(stream, encoding, -1);
            writer.Write(sampleString);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        public static Stream
        UseGetBytesAndMemoryStream(string sampleString, Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;

            var byteArray = encoding.GetBytes(sampleString);
            var memoryStream = new MemoryStream(byteArray);

            return memoryStream;
        }
    }
}