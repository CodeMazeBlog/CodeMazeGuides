namespace MemoryStreamInCsharp;

public static class Constructors
{
    public static MemoryStream SimpleConstructor() => 
        new MemoryStream();

    public static MemoryStream ByteArrayConstructor(byte[] bytes) => 
        new MemoryStream(bytes);

    public static MemoryStream FullConstructor(byte[] bytes, int count) => 
        new MemoryStream(bytes, 0, count, true, true);
}
