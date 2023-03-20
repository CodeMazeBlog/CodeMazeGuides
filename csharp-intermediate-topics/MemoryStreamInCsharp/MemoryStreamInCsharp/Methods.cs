using MemoryStreamInCsharp.Properties;
using System.Text;

namespace MemoryStreamInCsharp;

public static class Methods
{
    public static string ShowMemoryStreamProperties(MemoryStream memoryStream, string comment = "")
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(comment))
            sb.AppendLine($"{comment}\n--------------------------");

        sb.AppendLine($"{"Length:",-20}{memoryStream.Length}");
        sb.AppendLine($"{"Capacity:",-20}{memoryStream.Capacity}");
        sb.AppendLine($"{"CanRead:",-20}{memoryStream.CanRead}");
        sb.AppendLine($"{"CanSeek:",-20}{memoryStream.CanSeek}");
        sb.AppendLine($"{"CanWrite:",-20}{memoryStream.CanWrite}");
        sb.AppendLine($"{"CanTimeout:",-20}{memoryStream.CanTimeout}");
        sb.AppendLine($"{"publiclyVisible:",-20}{memoryStream.TryGetBuffer(out _)}");

        return sb.ToString();
    }

    public static void WriteToMemoryStream(MemoryStream memoryStream, byte[] bytes)
    {
        memoryStream.Write(bytes, 0, bytes.Length);
    }

    public static List<string> ReadFromMemoryStream(MemoryStream memoryStream)
    {
        var phrases = new List<string>();

        var buffer = new byte[10];
        memoryStream.Position = 0;
        memoryStream.Read(buffer, 0, 10);
        phrases.Add(Encoding.UTF8.GetString(buffer));

        buffer = new byte[20];
        memoryStream.Seek(10, SeekOrigin.Begin);
        memoryStream.ReadAtLeast(buffer, 20);
        phrases.Add(Encoding.UTF8.GetString(buffer));

        buffer = new byte[27];
        memoryStream.Seek(-27, SeekOrigin.End);
        memoryStream.ReadExactly(buffer, 0, 27);
        phrases.Add(Encoding.UTF8.GetString(buffer));

        return phrases;
    }

    public static void LoadImageFromResources()
    {
        var imageMemoryStream = Constructors.ByteArrayConstructor(Resources.Image);
        File.WriteAllBytes("Image.jpg", imageMemoryStream.ToArray());
    }

    public static byte[] SerializeObject(Person person)
    {
        var memoryStream = Constructors.SimpleConstructor();
        using var writer = new BinaryWriter(memoryStream);
        writer.Write(person.FirstName);
        writer.Write(person.LastName);
        writer.Write(person.Age);

        return memoryStream.ToArray();
    }

    public static Person DeserializeObject(byte[] serializedData)
    {
        Person deserializedPerson;
        var memoryStream = Constructors.ByteArrayConstructor(serializedData);
        using var reader = new BinaryReader(memoryStream);
        deserializedPerson = new Person
        {
            FirstName = reader.ReadString(),
            LastName = reader.ReadString(),
            Age = reader.ReadInt32()
        };

        return deserializedPerson;
    }
}

