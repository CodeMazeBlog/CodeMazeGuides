using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var numsResult = ReadOnlyMemoryOfIntToByteArray();
        Console.WriteLine(Convert.ToBase64String(numsResult)); // output: AQAAAAIAAAADAAAA

        var charsResult = ReadOnlyMemoryOfCharToByteArray();
        Console.WriteLine(Convert.ToBase64String(charsResult)); // output: ZgBvAG8A

        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var filePath = Path.Combine(documentsPath, "hello.txt");
        var content = "Hello, World!";
        SaveFile(filePath, content); // saves hello.txt in the Documents folder

        var hash = HashPassword("foo");
        Console.WriteLine(Convert.ToBase64String(hash)); // output: LCa0a2j/xo/5m0U8HTBBNBNCLXBkg7+g+YpeiGJm564=
    }

    public static byte[] ReadOnlyMemoryOfIntToByteArray()
    {
        ReadOnlyMemory<int> numbers = new int[] { 1, 2, 3 };
        var numsByteArray = MemoryMarshal.AsBytes(numbers.Span).ToArray();
        return numsByteArray;
    }

    public static byte[] ReadOnlyMemoryOfCharToByteArray()
    {
        ReadOnlyMemory<char> characters = "foo".AsMemory();
        var charsByteArray = MemoryMarshal.AsBytes(characters.Span).ToArray();
        return charsByteArray;
    }

    public static void SaveFile(string path, string content)
    {
        ReadOnlyMemory<byte> readOnlyMemory = Encoding.UTF8.GetBytes(content);
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            byte[] byteArray = readOnlyMemory.ToArray();
            stream.Write(byteArray, 0, byteArray.Length);
        }
    }

    public static byte[] HashPassword(string password)
    {
        ReadOnlyMemory<byte> passwordMemory = Encoding.UTF8.GetBytes(password);
        using (var hashAlgorithm = SHA256.Create())
        {
            byte[] byteArray = passwordMemory.ToArray();
            return hashAlgorithm.ComputeHash(byteArray);
        }
    }
}
