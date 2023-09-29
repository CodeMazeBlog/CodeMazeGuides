using CustomNamingPolicy;
using System.Text.Json;

namespace Test;

public class Tests
{

    private Person person;

    [SetUp]
    public void Setup()
    {
        person = new Person()
        {
            Name = "Name1",
            SurName = "Surname1"
        };
    }

    [Test]
    public void GivenPerson_WhenSerializeWithDefaultOptions_ReturnDefaultResult()
    {
        //Act
        var jsonString = JsonSerializer.Serialize(person);
        var expectedJson = "{\"Name\":\"Name1\",\"SurName\":\"Surname1\"}";

        //Assert
        Assert.AreEqual(expectedJson, jsonString);
    }

    [Test]
    public void GivenPerson_WhenSerializeWithFlatCasePolicy_ReturnFlatCasePolicyResult()
    {
        //Arange
        var jsonopts = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new FlatCasePolicy()
        };

        //Act
        var jsonString = JsonSerializer.Serialize(person, jsonopts);
        var expectedJson = "{\"name\":\"Name1\",\"surname\":\"Surname1\"}";

        //Assert
        Assert.AreEqual(expectedJson, jsonString);
    }

    [Test]
    public void GivenPerson_WhenSerializeWithCamelCasePolicy_ReturnCamelCasePolicyResult()
    {
        //Arange
        var jsonopts = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new CamelCasePolicy()
        };

        //Act
        var jsonString = JsonSerializer.Serialize(person, jsonopts);
        var expectedJson = "{\"name\":\"Name1\",\"surName\":\"Surname1\"}";

        //Assert
        Assert.AreEqual(expectedJson, jsonString);
    }
}