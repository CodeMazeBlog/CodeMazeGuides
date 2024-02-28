using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        var byteArray = ReadOnlyMemoryToByteArray<int>(new[] { 1, 2, 3 });
        Console.WriteLine(BitConverter.ToString(byteArray));

        byteArray = ReadOnlyMemoryToByteArray("foo".AsMemory());
        Console.WriteLine(BitConverter.ToString(byteArray));

        var path = Path.GetTempFileName();
        byteArray = SavePassword(path, "password".AsMemory());
        Console.WriteLine(BitConverter.ToString(byteArray));

        File.Delete(path);
    }

    public static byte[] ReadOnlyMemoryToByteArray<T>(ReadOnlyMemory<T> memory)
        where T : struct
    {
        return MemoryMarshal.AsBytes(memory.Span).ToArray();
    }

    public static byte[] SavePassword(string path, ReadOnlyMemory<char> password)
    {
        using var hashAlgorithm = SHA256.Create();
        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);

        byte[] byteArray = MemoryMarshal.AsBytes(password.Span).ToArray();
        stream.Write(byteArray, 0, byteArray.Length);

        return hashAlgorithm.ComputeHash(byteArray);
    }
}
