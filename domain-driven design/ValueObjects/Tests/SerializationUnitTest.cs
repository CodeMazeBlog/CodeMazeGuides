using System.Text.Json;
using ValueObjects.Entities;
using ValueObjects.Serialization;

namespace Tests;

public sealed class SerializationUnitTest
{
    [Test]
    public void GivenAUserWithEmailAddressObject_WhenUsingEmailAddressConverter_ThenCanSerializeItIntoString()
    {
        var user = new User(new("email@example.com"));
        var settings = new JsonSerializerOptions {Converters = {new EmailAddressConverter()}};
        var json = JsonSerializer.Serialize(user, settings);
        
        const string expectedJson = "{\"EmailAddress\":\"email@example.com\"}";
        Assert.That(json, Is.EqualTo(expectedJson));
    }

    [Test]
    public void GivenAUserWithEmailAddressJson_WhenUsingEmailAddressConverter_ThenCanDeserializeItIntoUser()
    {
        const string json = "{\"EmailAddress\":\"email@example.com\"}";
        var settings = new JsonSerializerOptions {Converters = {new EmailAddressConverter()}};
        var user = JsonSerializer.Deserialize<User>(json, settings);
        
        Assert.That(user, Is.Not.Null);
        Assert.That(user!.EmailAddress, Is.Not.Null);
        Assert.That(user.EmailAddress.Address, Is.EqualTo("email@example.com"));
    }
}