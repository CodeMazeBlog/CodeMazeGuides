using CustomJsonConverter.Converters;
using Newtonsoft.Json;
using Xunit;

namespace CustomJsonConverter.Tests;

public class ContactConverterUnitTest
{
    [Fact]
    public void GivenListOfContacts_WhenSerializedByContactConverter_ThenWritesOnlyNameAndDepartment()
    {
        var contacts = DataSource.GetContacts();

        var json = JsonConvert.SerializeObject(contacts, new ContactConverter());

        Assert.Equal(@"[{""Name"":""John"",""Department"":1},{""Name"":""Jane"",""Department"":2},{""Name"":""Mike"",""Department"":0}]", json);
    }

    [Fact]
    public void GivenListOfContacts_WhenSerializedByImprovedContactConverter_ThenWritesOnlyNameAndDepartment()
    {
        var contacts = DataSource.GetContacts();

        var json = JsonConvert.SerializeObject(contacts, new ImprovedContactConverter());

        Assert.Equal(@"[{""Name"":""John"",""Department"":1},{""Name"":""Jane"",""Department"":2},{""Name"":""Mike"",""Department"":0}]", json);
    }
}