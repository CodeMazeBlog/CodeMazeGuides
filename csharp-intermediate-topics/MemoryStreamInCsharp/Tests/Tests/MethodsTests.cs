using MemoryStreamInCsharp;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace Tests;

public class MethodsTests
{
    [Fact]
    public void WhenShowMemoryStreamProperties_ThenSuccess()
    {
        var memoryStream = Constructors.SimpleConstructor();
        var displayProperties = Methods.ShowMemoryStreamProperties(memoryStream);
        Assert.Contains("Length:             0", displayProperties);
        Assert.Contains("Capacity:           0", displayProperties);
        Assert.Contains("CanRead:            True", displayProperties);
        Assert.Contains("CanSeek:            True", displayProperties);
        Assert.Contains("CanWrite:           True", displayProperties);
        Assert.Contains("CanTimeout:         False", displayProperties);
        Assert.Contains("publiclyVisible:    True", displayProperties);
    }

    [Fact]
    public void WhenWritingToExtendibleMemoryStream_ThenSuccess()
    {
        var memoryStream = Constructors.SimpleConstructor();
        var addBytes = new byte[20];
        Methods.WriteToMemoryStream(memoryStream, addBytes);
        Assert.True(memoryStream.Length == 20);
    }

    [Fact]
    public void WhenWritingOverTheCapacity_ThenFailure()
    {
        var memoryStream = Constructors.ByteArrayConstructor(new byte[10]);
        var addBytes = new byte[20];
        Assert.Throws<NotSupportedException>(() => memoryStream.Write(addBytes, 0, addBytes.Length));
    }

    [Fact]
    public void WhenWritingWithinTheCapacity_ThenSuccess()
    {
        var memoryStream = Constructors.ByteArrayConstructor(new byte[10]);
        var addBytes = new byte[5] { 1, 1, 1, 1, 1 };
        Methods.WriteToMemoryStream(memoryStream, addBytes);
        Assert.True(memoryStream.Length == 10);
        Assert.True(memoryStream.Capacity == 10);
    }

    [Fact]
    public void WhenReadingFromMemoryStream_ThenSuccess()
    {
        var memoryStream = Constructors.SimpleConstructor();
        var phrase1 = "How to Use MemoryStream in C#";
        var phrase1Bytes = Encoding.UTF8.GetBytes(phrase1);
        var phrase2 = " - explanation with examples";
        var phrase2Bytes = Encoding.UTF8.GetBytes(phrase2);

        Methods.WriteToMemoryStream(memoryStream, phrase1Bytes);
        Methods.WriteToMemoryStream(memoryStream, phrase2Bytes);

        var phrases = Methods.ReadFromMemoryStream(memoryStream);
        Assert.Equal("How to Use", phrases[0]);
        Assert.Equal(" MemoryStream in C# ", phrases[1]);
        Assert.Equal("- explanation with examples", phrases[2]);

        var fullPhrase = Encoding.UTF8.GetString(memoryStream.ToArray());
        Assert.Equal("How to Use MemoryStream in C# - explanation with examples", fullPhrase);
    }

    [Fact]
    public void WhenSerializeAndDeserializePerson_ThenSuccess()
    {
        var person = new Person("Jack", "Black", 30);

        byte[] serializedData = Methods.SerializeObject(person);
        Assert.True(serializedData.Length > 0);

        var deserializedPerson = Methods.DeserializeObject(serializedData);
        Assert.Equal(person.FirstName, deserializedPerson.FirstName);
        Assert.Equal(person.LastName, deserializedPerson.LastName);
        Assert.Equal(person.Age, deserializedPerson.Age);
    }

    [Fact]
    public void WhenLoadImageFromResources_ThenSuccess()
    {
        Methods.LoadImageFromResources();

        var fi = new FileInfo("Image.jpg");
        Assert.True(fi.Exists);
        Assert.True(fi.Length > 0);
    }
}