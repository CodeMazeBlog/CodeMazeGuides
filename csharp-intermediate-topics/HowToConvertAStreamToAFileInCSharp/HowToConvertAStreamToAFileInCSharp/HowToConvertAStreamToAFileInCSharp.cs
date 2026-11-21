namespace HowToConvertAStreamToAFileInCSharp;

public static class ConvertAStreamToAFileInCSharp
{
    public static void CopyToFile(MemoryStream stream, string path)
    {
        using var fileStream = File.Create(path);
        stream.Position = 0;
        stream.CopyTo(fileStream);
    }

    public static async Task CopyToFileAsync(MemoryStream stream, string path)
    {
        await using var fileStream = File.Create(path);
        stream.Position = 0;
        await stream.CopyToAsync(fileStream);
    }

    public static void WriteToFileStream(MemoryStream stream, string path)
    {
        using var fileStream = File.Create(path);
        fileStream.Write(stream.ToArray());
    }

    public static void WriteAllBytesFile(MemoryStream stream, string path)
    {
        File.WriteAllBytes(path, stream.ToArray());
    }

    public static void WriteByteToFileStream(MemoryStream stream, string path)
    {
        using var fileStream = File.Create(path);
        stream.Position = 0;
        while (stream.Position < stream.Length)
        {
            fileStream.WriteByte((byte)stream.ReadByte());
        }
    }
}
