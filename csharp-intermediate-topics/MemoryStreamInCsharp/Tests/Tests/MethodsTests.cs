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
        Assert.True(phrases[0].Equals("How to Use"));
        Assert.True(phrases[1].Equals(" MemoryStream in C# "));
        Assert.True(phrases[2].Equals("- explanation with examples"));

        var fullPhrase = Encoding.UTF8.GetString(memoryStream.ToArray());
        Assert.True(fullPhrase.Equals("How to Use MemoryStream in C# - explanation with examples"));
    }

    [Fact]
    public void WhenSerializeAndDeserializePerson_ThenSuccess()
    {
        var person = new Person
        {
            FirstName = "Jack",
            LastName = "Black",
            Age = 30
        };

        byte[] serializedData = Methods.SerializeObject(person);
        Assert.True(serializedData.Length > 0);

        var deserializedPerson = Methods.DeserializeObject(serializedData);
        Assert.True(person.FirstName.Equals(deserializedPerson.FirstName));
        Assert.True(person.LastName.Equals(deserializedPerson.LastName));
        Assert.True(person.Age == deserializedPerson.Age);
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