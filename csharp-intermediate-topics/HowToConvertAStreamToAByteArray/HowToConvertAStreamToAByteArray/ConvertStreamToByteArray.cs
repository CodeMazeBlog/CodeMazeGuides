namespace HowToConvertAStreamToAByteArray
{
    public class ConvertStreamToByteArray
    {
        public byte[] UseStreamDotReadMethod(Stream stream)
        {
            byte[] bytes;
            List<byte> totalStream = new();
            byte[] buffer = new byte[32];
            int read;

            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalStream.AddRange(buffer.Take(read));
            }
            bytes = totalStream.ToArray();

            return bytes;
        }

        public byte[] UseBinaryReader(Stream stream)
        {
            byte[] bytes;

            using (var binaryReader = new BinaryReader(stream))
            {
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }

            return bytes;
        }

        public byte[] UseStreamReader(Stream stream)
        {
            byte[] bytes;

            using (var reader = new StreamReader(stream))
            {
                bytes = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }

            return bytes;
        }

        public byte[] UseMemoryStream(Stream stream)
        {
            byte[] bytes;

            if (stream is MemoryStream memStream)
            {
                return memStream.ToArray();
            }

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }

        public byte[] UseBufferedStream(Stream stream)
        {
            byte[] bytes;

            using (var bufferedStream = new BufferedStream(stream))
            {
                using var memoryStream = new MemoryStream();
                bufferedStream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
                
            return bytes;
        }
    }
}