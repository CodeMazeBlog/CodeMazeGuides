namespace HowToConvertAStreamToAByteArray
{
    public class ConvertStreamToByteArray
    {
        private readonly Stream _stream;

        public ConvertStreamToByteArray(Stream stream)
        {
            _stream = stream;
        }

        public byte[] UseStreamDotReadMethod()
        {
            byte[] bytes;
            List<byte> totalStream = new();
            byte[] buffer = new byte[32];
            int read;

            while ((read = _stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalStream.AddRange(buffer.Take(read));
            }
            bytes = totalStream.ToArray();

            return bytes;
        }

        public byte[] UseBinaryReader()
        {
            byte[] bytes;

            using (var binaryReader = new BinaryReader(_stream))
            {
                bytes = binaryReader.ReadBytes((int)_stream.Length);
            }

            return bytes;
        }

        public byte[] UseStreamReader()
        {
            byte[] bytes;

            using (var reader = new StreamReader(_stream))
            {
                bytes = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }

            return bytes;
        }

        public byte[] UseMemoryStream()
        {
            byte[] bytes;

            if (_stream is MemoryStream stream)
            {
                return stream.ToArray();
            }

            using (var memoryStream = new MemoryStream())
            {
                _stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }

        public byte[] UseBufferedStream()
        {
            byte[] bytes;

            using (var bufferedStream = new BufferedStream(_stream))
            {
                using var memoryStream = new MemoryStream();
                bufferedStream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
                
            return bytes;
        }
    }
}