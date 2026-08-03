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

    public static byte[] ReadOnlyMemoryToByteArray<T>(ReadOnlyMemory<T> input)
        where T : struct
    {
        return MemoryMarshal.AsBytes(input.Span).ToArray();
    }

    public static byte[] SaveText(string path, ReadOnlyMemory<char> text)
    {
        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        var byteArray = MemoryMarshal.AsBytes(text.Span).ToArray();
        stream.Write(byteArray, 0, byteArray.Length);

        using var hashAlgorithm = SHA256.Create();
        return hashAlgorithm.ComputeHash(byteArray);
    }
}
