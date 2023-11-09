using System.Text;
using MemoryStreamInCsharp;

var phrase1 = "How to Use MemoryStream in C#";
var phrase1Bytes = Encoding.UTF8.GetBytes(phrase1);
var phrase2 = " - explanation with examples";
var phrase2Bytes = Encoding.UTF8.GetBytes(phrase2);

var memoryStream = Constructors.SimpleConstructor();
var displayProperties = Methods.ShowMemoryStreamProperties(memoryStream,
    "Simple Constructor");
Console.WriteLine($"{displayProperties}");

memoryStream = Constructors.ByteArrayConstructor(phrase1Bytes);
displayProperties = Methods.ShowMemoryStreamProperties(memoryStream,
    "Constructed From byte array");
Console.WriteLine($"{displayProperties}");

memoryStream = Constructors.FullConstructor(phrase1Bytes, phrase1Bytes.Length - 10);
displayProperties = Methods.ShowMemoryStreamProperties(memoryStream,
    "Constructed Writable from byte array with GetBuffer() enabled");
Console.WriteLine($"{displayProperties}\n");

memoryStream = Constructors.SimpleConstructor();
Methods.WriteToMemoryStream(memoryStream, phrase1Bytes);
Methods.WriteToMemoryStream(memoryStream, phrase2Bytes);
displayProperties = Methods.ShowMemoryStreamProperties(memoryStream,
    "Writing to MemoryStream");
Console.WriteLine(displayProperties);

var phrases = Methods.ReadFromMemoryStream(memoryStream);
for (var i = 0; i < phrases.Count; i++)
    Console.WriteLine($"Phrase {i + 1}: {phrases[i]}");

var fullPhrase = Encoding.UTF8.GetString(memoryStream.ToArray());
Console.WriteLine("Full phrase: {0}", fullPhrase);

Methods.LoadImageFromResources();

var person = new Person
{
    FirstName = "Jack",
    LastName = "Black",
    Age = 30
};
byte[] serializedData = Methods.SerializeObject(person);
var deserializedPerson = Methods.DeserializeObject(serializedData);
Console.WriteLine($"\nFirst Name: {deserializedPerson.FirstName}, " +
    $"Last Name: {deserializedPerson.LastName}, " +
    $"Age: {deserializedPerson.Age}");