namespace DifferentWaysToOverwiteAFile.Examples
{
    public class FileStreamWithFileMode
    {
        public static void OverwiteFile(string filePath, byte[] bytes)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
