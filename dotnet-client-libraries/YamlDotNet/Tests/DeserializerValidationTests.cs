using App.Models;
using App.UseCases;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;

namespace Tests;

public class DeserializerValidationTests
{
    [Fact]
    public void WhenValidYamlIsDeserialized_ThenPersonIsReturned()
    {
        var yaml = $"Name: Test{Environment.NewLine}Age: 30";
        var expectedPerson = new Person { Name = "Test", Age = 30 };
        var deserializer = new DeserializerBuilder().WithNodeDeserializer
        (i => new DeserializerValidation(i),
            s => s.InsteadOf<ObjectNodeDeserializer>()).Build();
        var actualPerson = deserializer.Deserialize<Person>(yaml);

        Assert.Equal(expectedPerson.Name, actualPerson.Name);
        Assert.Equal(expectedPerson.Age, actualPerson.Age);
    }

    [Fact]
    public void WhenInvalidYamlIsDeserialized_ThenExceptionIsThrown()
    {
        var yaml = "Name: ~";
        var deserializer = new DeserializerBuilder().WithNodeDeserializer
        (i => new DeserializerValidation(i),
            s => s.InsteadOf<ObjectNodeDeserializer>()).Build();

        Assert.Throws<YamlException>(() => deserializer.Deserialize<Person>(yaml));
    }
}