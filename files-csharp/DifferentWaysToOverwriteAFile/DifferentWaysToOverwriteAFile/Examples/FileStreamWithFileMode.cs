namespace DifferentWaysToOverwriteAFile.Examples;

public static class FileStreamWithFileMode
{
    public static void OverwriteFile(string filePath, byte[] fileContent)
    {
        using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        fileStream.Write(fileContent, 0, fileContent.Length);
    }
}
