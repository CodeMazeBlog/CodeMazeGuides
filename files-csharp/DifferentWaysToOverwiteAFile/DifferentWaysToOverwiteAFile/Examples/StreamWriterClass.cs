namespace DifferentWaysToOverwiteAFile.Examples;

public static class StreamWriterClass
{
    public static void AppendFile(string filePath, string contentToWrite)
    {
        using var streamWriter = new StreamWriter(filePath, true);
        streamWriter.Write(contentToWrite);
    }

    public static void OverwiteFile(string filePath, string contentToWrite)
    {
        using var streamWriter = new StreamWriter(filePath, false);
        streamWriter.Write(contentToWrite);
    }
}
