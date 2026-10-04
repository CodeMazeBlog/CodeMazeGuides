using CustomJsonConverter.Converters;
using Newtonsoft.Json;
using Xunit;

namespace CustomJsonConverter.Tests;

[JsonConverter(typeof(ImprovedContactConverter))]
public record class TaggedContact(string Name, Department Department, string Phone, Address Address)
    : Contact(Name, Department, Phone, Address);

public class ConverterRegistrationUnitTest
{
    [Fact]
    public void GivenListOfContacts_WhenConverterIsRegisteredInSettings_ThenWritesCustomizedOutput()
    {
        var contacts = DataSource.GetContacts();
        var settings = new JsonSerializerSettings
        {
            Converters = { new SmartContactConverter() }
        };

        var json = JsonConvert.SerializeObject(contacts, settings);

        Assert.Equal(@"[{""Name"":""John"",""Department"":""Admin"",""Address"":{""Street"":""Street 1"",""City"":""City 1""}},{""Name"":""Jane"",""Department"":""CustomerCare"",""Phone"":""+2341"",""Address"":{""Street"":""Street 2"",""City"":""City 2""}},{""Name"":""Mike"",""Department"":""Operations"",""Address"":{""Street"":""Street 3"",""City"":""City 3""}}]", json);
    }

    [Fact]
    public void GivenTypeWithConverterAttribute_WhenRoundTripped_ThenConverterWritesAndDefaultContractReads()
    {
        var contact = new TaggedContact("John", Department.Admin, "+1234", new("Street 1", "City 1"));

        var json = JsonConvert.SerializeObject(contact);

        Assert.Equal(@"{""Name"":""John"",""Department"":1}", json);

        var restored = JsonConvert.DeserializeObject<TaggedContact>(json)!;

        Assert.Equal("John", restored.Name);
        Assert.Equal(Department.Admin, restored.Department);
        Assert.Null(restored.Phone);
    }
}
