namespace DifferentWaysToOverwriteAFile.Examples;

public static class FileWriter
{
    public static void OverwriteFileWithBytes(string filePath, byte[] fileContent)
    {
        File.WriteAllBytes(filePath, fileContent);
    }

    public static void OverwriteFileWithText(string filePath, string fileContent)
    {
        File.WriteAllText(filePath, fileContent);
    }
}
