namespace DifferentWaysToOverwriteAFile.Examples;

public static class FileOpenWithFileMode
{
    public static void OverwriteFile(string filePath, byte[] fileContent)
    {
        using var stream = File.Open(filePath, FileMode.Create);
        stream.Write(fileContent, 0, fileContent.Length);
    }
}
