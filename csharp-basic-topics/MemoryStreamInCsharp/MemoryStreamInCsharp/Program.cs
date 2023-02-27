using MemoryStreamInCsharp.Properties;
using System.Text;
using MemoryStreamInCsharp;

var phrase1 = "How to Use MemoryStream in C#";
var phrase1Bytes = Encoding.UTF8.GetBytes(phrase1);
var phrase2 = " - explanation with examples";
var phrase2Bytes = Encoding.UTF8.GetBytes(phrase2);
var memoryStream = new MemoryStream();

SimpleConstructor();
ByteArrayConstructor();
FullConstructor();

WriteToMemoryStream();
ReadFromMemoryStream();

LoadImageFromResources();

SerializeAndDeserializeObject();

string ShowMemoryStreamProperties(MemoryStream memoryStream, string comment = "")
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

void SimpleConstructor()
{
    MemoryStream memoryStream = new MemoryStream();
    var displyProperties = ShowMemoryStreamProperties(memoryStream, 
        "Simple Constructor");

    Console.WriteLine($"{displyProperties}");
}

void ByteArrayConstructor()
{
    var memoryStream = new MemoryStream(phrase1Bytes);
    var displyProperties = ShowMemoryStreamProperties(memoryStream, 
        "Constructed From byte array");

    Console.WriteLine($"{displyProperties}");
}

void FullConstructor()
{
    var memoryStream = new MemoryStream(phrase1Bytes, 0, phrase1Bytes.Length - 10, true, true);
    var displyProperties = ShowMemoryStreamProperties(memoryStream, 
        "Constructed Writable from byte array with GetBuffer() enabled");

    Console.WriteLine($"{displyProperties}\n");
}

void WriteToMemoryStream()
{
    memoryStream.Write(phrase1Bytes, 0, phrase1Bytes.Length);
    memoryStream.Write(phrase2Bytes, 0, phrase2Bytes.Length);
    var displyProperties = ShowMemoryStreamProperties(memoryStream, 
        "Writing to MemoryStream");

    Console.WriteLine(displyProperties);
}

void ReadFromMemoryStream()
{
    var buffer = new byte[10];
    memoryStream.Position = 0;
    memoryStream.Read(buffer, 0, 10);
    Console.WriteLine("Phrase 1: {0}", Encoding.UTF8.GetString(buffer));

    buffer = new byte[20];
    memoryStream.Seek(10, SeekOrigin.Begin);
    memoryStream.ReadAtLeast(buffer, 20);
    Console.WriteLine("Phrase 2: {0}", Encoding.UTF8.GetString(buffer));

    buffer = new byte[27];
    memoryStream.Seek(-27, SeekOrigin.End);
    memoryStream.ReadExactly(buffer, 0, 27);
    Console.WriteLine("Phrase 3: {0}", Encoding.UTF8.GetString(buffer));

    var fullPhrase = Encoding.UTF8.GetString(memoryStream.ToArray());
    Console.WriteLine("Full phrase: {0}", fullPhrase);
}

void LoadImageFromResources()
{
    var imageMemoryStream = new MemoryStream(Resources.Image);

    byte[] imageHeaderBytes = new byte[4];
    imageMemoryStream.ReadExactly(imageHeaderBytes);

    Console.WriteLine($"Image header: {BitConverter.ToString(imageHeaderBytes)}");

    File.WriteAllBytes("Image.jpg", imageMemoryStream.ToArray());
}

void SerializeAndDeserializeObject()
{
    Person person = new Person
    {
        FirstName = "Jack",
        LastName = "Black",
        Age = 30
    };

    byte[] serializedData;
    var memoryStream = new MemoryStream();
    using (var writer = new BinaryWriter(memoryStream))
    {
        writer.Write(person.FirstName);
        writer.Write(person.LastName);
        writer.Write(person.Age);

        memoryStream.Position = 0;
        serializedData = memoryStream.ToArray();
    }

    Person deserializedPerson;
    memoryStream = new MemoryStream(serializedData);
    using (var reader = new BinaryReader(memoryStream))
    {
        deserializedPerson = new Person
        {
            FirstName = reader.ReadString(),
            LastName = reader.ReadString(),
            Age = reader.ReadInt32()
        };
    }

    Console.WriteLine($"\nFirst Name: {deserializedPerson.FirstName}, " +
        $"Last Name: {deserializedPerson.LastName}, " +
        $"Age: {deserializedPerson.Age}");
}