using System.Text.Json;
using ValueObjects.Entities;
using ValueObjects.Serialization;

namespace Tests;

public sealed class SerializationUnitTest
{
    [Fact]
    public void GivenAUserWithEmailAddressObject_WhenUsingEmailAddressConverter_ThenCanSerializeItIntoString()
    {
        var user = new User(new("email@example.com"));
        var settings = new JsonSerializerOptions { Converters = { new EmailAddressConverter() } };
        var json = JsonSerializer.Serialize(user, settings);

        const string expectedJson = "{\"EmailAddress\":\"email@example.com\"}";
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenAUserWithEmailAddressJson_WhenUsingEmailAddressConverter_ThenCanDeserializeItIntoUser()
    {
        const string json = "{\"EmailAddress\":\"email@example.com\"}";
        var settings = new JsonSerializerOptions { Converters = { new EmailAddressConverter() } };
        var user = JsonSerializer.Deserialize<User>(json, settings);

        Assert.NotNull(user);
        Assert.NotNull(user.EmailAddress);
        Assert.Equal("email@example.com", user.EmailAddress.Address);
    }
}
