namespace DifferentWaysToOverwriteAFile.Examples;

public static class FileWriter
{
    public static void OverwriteFileWithBytes(string filePath, byte[] contentToWrite)
    {
        File.WriteAllBytes(filePath, contentToWrite);
    }

    public static void OverwriteFileWithText(string filePath, string contentToWrite)
    {
        File.WriteAllText(filePath, contentToWrite);
    }
}
