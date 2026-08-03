namespace ByteArrayToFile;

public static class ByteArrayToFileConverter
{
    public static void SaveByteArrayToFileWithBinaryWriter(byte[] data, string filePath)
    {
        using var writer = new BinaryWriter(File.OpenWrite(filePath));
        writer.Write(data);
    }
    public static void SaveByteArrayToFileWithFileStream(byte[] data, string filePath)
    {
        using var stream = File.Create(filePath);
        stream.Write(data, 0, data.Length);
    }

    public static void SaveByteArrayToFileWithStaticMethod(byte[] data, string filePath)
        => File.WriteAllBytes(filePath, data);
}
