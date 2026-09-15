using System.Text.Json;

namespace CamelCaseSerialization.Tests;

public class ExtensionTests
{
    [Fact]
    public void GivenPerson_WhenUsingExtensionMethod_ThenSerializeWithCamelCase()
    {
        var person = new Person
        {
            Age = 20,
            FirstName = "John",
            Surname = "Doe",
            IsActive = true
        };

        var result = person.SerializeWithCamelCase();
        
        Assert.Equal("""{"firstName":"John","surname":"Doe","age":20,"isActive":true}""", result);
    }
    
    [Fact]
    public void GivenJsonStringInCamelCase_WhenUsingExtensionMethod_ThenDeserializeIntoObject()
    {
        var personJson = """{"firstName":"John","surname":"Doe","age":20,"isActive":true}""";

        var result = personJson.DeserializeFromCamelCase<Person>();

        Assert.NotNull(result);
        Assert.Equal(20, result.Age);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.Surname);
        Assert.True(result.IsActive);
    }

    [Fact]
    public void GivenPerson_WhenSerializingWithWebDefaults_ThenPropertyNamesAreCamelCase()
    {
        var person = new Person
        {
            Age = 20,
            FirstName = "John",
            Surname = "Doe",
            IsActive = true
        };
        var webOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        var result = JsonSerializer.Serialize(person, webOptions);

        Assert.Equal("""{"firstName":"John","surname":"Doe","age":20,"isActive":true}""", result);
    }
}
