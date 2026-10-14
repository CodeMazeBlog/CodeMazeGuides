namespace ByteArrayToFile;

public static class ByteArrayToFileConverter
{
    public static void SaveByteArrayToFileWithBinaryWriter(byte[] data, string filePath)
    {
        using var writer = new BinaryWriter(File.Create(filePath));
        writer.Write(data);
    }
    public static void SaveByteArrayToFileWithFileStream(byte[] data, string filePath)
    {
        using var stream = File.Create(filePath);
        stream.Write(data, 0, data.Length);
    }

    public static void SaveByteArrayToFileWithStaticMethod(byte[] data, string filePath)
        => File.WriteAllBytes(filePath, data);

    public static Task SaveByteArrayToFileAsync(byte[] data, string filePath, CancellationToken token = default)
        => File.WriteAllBytesAsync(filePath, data, token);

    public static void AppendByteArrayToFile(byte[] data, string filePath)
        => File.AppendAllBytes(filePath, data);

    public static void SaveByteArrayToFileAtOffset(byte[] data, string filePath, long offset)
    {
        using var handle = File.OpenHandle(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        RandomAccess.Write(handle, data, offset);
    }
}
