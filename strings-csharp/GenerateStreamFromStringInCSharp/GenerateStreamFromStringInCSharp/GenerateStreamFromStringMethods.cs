using System.Text;

namespace GenerateStreamFromStringInCSharp
{
    public static class GenerateStreamFromStringMethods
    {
        public static Stream GenerateStreamFromString(string sampleString, Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;

            using var stream = new MemoryStream(encoding.GetByteCount(sampleString));
            using var writer = new StreamWriter(stream, encoding);
            writer.Write(sampleString);
            stream.Position = 0;

            return stream;
        }

        public static Stream ConciselyGenerateStreamFromString(string sampleString, Encoding? encoding = null)
            => new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(sampleString ?? string.Empty));
    }
}