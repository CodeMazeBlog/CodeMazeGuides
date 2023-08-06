namespace DifferentWaysToOverwiteAFile.Examples;

public static class FileWriter
{
    public static void OverwiteFileWithBytes(string filePath, byte[] contentToWrite)
    {
        File.WriteAllBytes(filePath, contentToWrite);
    }

    public static void OverwiteFileWithText(string filePath, string contentToWrite)
    {
        File.WriteAllText(filePath, contentToWrite);
    }
}
