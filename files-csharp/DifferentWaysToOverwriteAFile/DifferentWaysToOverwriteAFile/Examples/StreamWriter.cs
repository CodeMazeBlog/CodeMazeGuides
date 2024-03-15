namespace DifferentWaysToOverwriteAFile.Examples;

public static class StreamWriter
{
    public static void AppendFile(string filePath, string fileContent)
    {
        using var streamWriter = new System.IO.StreamWriter(filePath, true);
        streamWriter.Write(fileContent);
    }

    public static void OverwriteFile(string filePath, string fileContent)
    {
        using var streamWriter = new System.IO.StreamWriter(filePath, false);
        streamWriter.Write(fileContent);
    }
}
