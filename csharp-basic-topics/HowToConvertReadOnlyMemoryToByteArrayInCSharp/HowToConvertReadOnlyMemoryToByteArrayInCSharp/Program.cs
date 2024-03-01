using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        const string text = "foo";

        var byteArray = ReadOnlyMemoryToByteArray<int>(new[] { 1, 2, 3 });
        Console.WriteLine(BitConverter.ToString(byteArray));

        byteArray = ReadOnlyMemoryToByteArray(text.AsMemory());
        Console.WriteLine(BitConverter.ToString(byteArray));

        var path = Path.GetTempFileName();
        byteArray = SaveText(path, text.AsMemory());
        Console.WriteLine(BitConverter.ToString(byteArray));

        File.Delete(path);
    }

    public static byte[] ReadOnlyMemoryToByteArray<T>(ReadOnlyMemory<T> memory)
        where T : struct
    {
        return MemoryMarshal.AsBytes(memory.Span).ToArray();
    }

    public static byte[] SaveText(string path, ReadOnlyMemory<char> text)
    {
        using var hashAlgorithm = SHA256.Create();
        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);

        var byteArray = MemoryMarshal.AsBytes(text.Span).ToArray();
        stream.Write(byteArray, 0, byteArray.Length);

        return hashAlgorithm.ComputeHash(byteArray);
    }
}
