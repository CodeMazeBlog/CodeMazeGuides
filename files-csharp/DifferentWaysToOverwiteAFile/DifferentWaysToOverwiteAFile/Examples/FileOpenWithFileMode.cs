namespace DifferentWaysToOverwiteAFile.Examples;

public static class FileOpenWithFileMode
{
    public static void OverwriteFile(string filePath, byte[] bytes)
    {
        using var stream = File.Open(filePath, FileMode.Create);
        stream.Write(bytes, 0, bytes.Length);
    }
}
