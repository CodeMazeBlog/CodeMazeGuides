namespace DifferentWaysToOverwiteAFile.Examples
{
    public class WriteAllText
    {
        public static void OverwiteFile(string filePath, string contentToWrite)
        {
            File.WriteAllText(filePath, contentToWrite);
        }
    }
}
