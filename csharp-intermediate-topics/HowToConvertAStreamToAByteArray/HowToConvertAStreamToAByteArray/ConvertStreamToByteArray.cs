namespace HowToConvertAStreamToAByteArray
{
    public class ConvertStreamToByteArray
    {
        private readonly Stream _stream;

        public ConvertStreamToByteArray(Stream stream)
        {
            _stream = stream;
        }

        public byte[] UseTheStreamDotReadMethod()
        {
            List<byte> totalStream = new();
            byte[] buffer = new byte[32];
            int read;
            while ((read = _stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalStream.AddRange(buffer.Take(read));
            }

            return totalStream.ToArray();
        }

        public byte[] UseABinaryReader()
        {
            var binaryReader = new BinaryReader(_stream);

            return binaryReader.ReadBytes((int)_stream.Length);
        }

        public byte[] UseAStreamReader()
        {
            var reader = new StreamReader(_stream);

            return System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
        }

        public byte[] UseAMemoryStream()
        {
            if (_stream is MemoryStream stream)
            {
                return stream.ToArray();
            }
            var memoryStream = new MemoryStream();
            _stream.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }

        public byte[] UseABufferedStream()
        {
            byte[] byteArray;
            var bufferedStream = new BufferedStream(_stream);
            var memoryStream = new MemoryStream();
            bufferedStream.CopyTo(memoryStream);
            byteArray = memoryStream.ToArray();

            return byteArray;
        }
    }
}