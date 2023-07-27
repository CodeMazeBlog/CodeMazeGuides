namespace DifferentWaysToOverwiteAFile.Examples
{
    public class WriteAllBytes
    {
        public static void OverwiteFile(string filePath, byte[] contentToWrite)
        {
            File.WriteAllBytes(filePath, contentToWrite);
        }
    }
}
