namespace DifferentWaysToOverwiteAFile.Examples;

public static class FileStreamWithFileMode
{
    public static void OverwriteFile(string filePath, byte[] bytes)
    {
        using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        fileStream.Write(bytes, 0, bytes.Length);
    }
}
