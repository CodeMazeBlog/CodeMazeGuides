namespace FileToByteArray
{
    public class Program
    {
        static void Main()
        {
            string filePath = "Files/CodeMaze.pdf";

            var fileByteArray = ConvertToByteArray(filePath);

            var fileByteArrayFromChunks = ConvertToByteArrayChunked(filePath);
        }

        public static byte[] ConvertToByteArray(string filePath)
        {
            byte[] fileByteArray = File.ReadAllBytes(filePath);

            return fileByteArray;
        }

        public static byte[] ConvertToByteArrayChunked(string filePath)
        {
            const int MaxChunkSizeInBytes = 2048;

            byte[] fileByteArray;
            var fileByteArrayChunk = new byte[MaxChunkSizeInBytes];
            var totalBytes = 0;

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;

                while ((bytesRead = stream.Read(fileByteArrayChunk, 0, fileByteArrayChunk.Length)) > 0)
                {
                    totalBytes += bytesRead;
                }

                fileByteArray = new byte[totalBytes];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(fileByteArray, 0, totalBytes);
            }

            return fileByteArray;
        }
    }
}