using App.Models;
using App.UseCases;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;
using static System.Environment;

namespace Tests;

public class DeserializerValidationTests
{
    [Fact]
    public void GivenYamlIsValid_WhenYamlIsDeserialized_ThenPersonIsReturned()
    {
        var yaml = $"Name: Test{NewLine}Age: 30";
        var expectedPerson = new Person { Name = "Test", Age = 30 };
        var deserializer = new DeserializerBuilder().WithNodeDeserializer
        (i => new DeserializerValidation(i),
            s => s.InsteadOf<ObjectNodeDeserializer>()).Build();
        var actualPerson = deserializer.Deserialize<Person>(yaml);

        Assert.Equal(expectedPerson.Name, actualPerson.Name);
        Assert.Equal(expectedPerson.Age, actualPerson.Age);
    }

    [Fact]
    public void GivenYamlIsInvalid_WhenYamlIsDeserialized_ThenExceptionIsThrown()
    {
        var yaml = "Name: ~";
        var deserializer = new DeserializerBuilder().WithNodeDeserializer
        (i => new DeserializerValidation(i),
            s => s.InsteadOf<ObjectNodeDeserializer>()).Build();

        Assert.Throws<YamlException>(() => deserializer.Deserialize<Person>(yaml));
    }
}