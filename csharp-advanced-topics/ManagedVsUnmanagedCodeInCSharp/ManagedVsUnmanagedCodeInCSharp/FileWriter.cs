using System.Text;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public class FileWriter
    {
        public static void WriteDataToFile(string fileName, string data)
        {
            using var fileStream = new FileStream(fileName, FileMode.Create);
            var bytes = Encoding.UTF8.GetBytes(data);
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
