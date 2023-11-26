using System.Text.Json;
using CustomNamingPolicy;

namespace Test;

public class Tests
{
    private Person _person;

    [SetUp]
    public void Setup()
    {
        _person = new Person()
        {
            GivenName = "Name1",
            surName = "Surname1"
        };
    }

    [Test]
    public void GivenPerson_WhenSerializeWithDefaultOptions_ReturnDefaultResult()
    {
        //Act
        var jsonString = JsonSerializer.Serialize(_person);
        var expectedJson = "{\"GivenName\":\"Name1\",\"surName\":\"Surname1\"}";

        //Assert
        Assert.AreEqual(expectedJson, jsonString);
    }

    [Test]
    public void GivenPerson_WhenSerializeWithNodeSeparatorPolicy_ReturnNodeSeparatorPolicyResult()
    {
        //Arange
        var jsonopts = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new NodeSeparatorPolicy()
        };

        //Act
        var jsonString = JsonSerializer.Serialize(_person, jsonopts);
        var expectedJson = "{\"given/name\":\"Name1\",\"sur/name\":\"Surname1\"}";

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
        var jsonString = JsonSerializer.Serialize(_person, jsonopts);
        var expectedJson = "{\"givenName\":\"Name1\",\"surName\":\"Surname1\"}";

        //Assert
        Assert.AreEqual(expectedJson, jsonString);
    }
}