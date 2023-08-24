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
        
        Assert.Equal(result, """{"firstName":"John","surname":"Doe","age":20,"isActive":true}""");
    }
    
    [Fact]
    public void GivenJsonStringInCamelCase_WhenUsingExtensionMethod_ThenDeserializeIntoObject()
    {
        var personJson = """{"firstName":"John","surname":"Doe","age":20,"isActive":true}""";

        var result = personJson.DeserializeFromCamelCase<Person>();
        
        Assert.Equal(result.Age, 20);
        Assert.Equal(result.FirstName, "John");
        Assert.Equal(result.Surname, "Doe");
        Assert.Equal(result.IsActive, true);
    }
}
