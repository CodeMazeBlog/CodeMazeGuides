using CustomJsonConverter.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace CustomJsonConverter.Tests;

public class SmartContactConverterUnitTest
{
    [Fact]
    public void GivenListOfContacts_WhenSerializedBySmartContactConverter_ThenWritesCustomizedOutput()
    {
        var contacts = DataSource.GetContacts();

        var json = JsonConvert.SerializeObject(contacts, new SmartContactConverter());

        Assert.Equal(@"[{""Name"":""John"",""Department"":""Admin"",""Address"":{""Street"":""Street 1"",""City"":""City 1""}},{""Name"":""Jane"",""Department"":""CustomerCare"",""Phone"":""+2341"",""Address"":{""Street"":""Street 2"",""City"":""City 2""}},{""Name"":""Mike"",""Department"":""Operations"",""Address"":{""Street"":""Street 3"",""City"":""City 3""}}]", json);
    }

    [Fact]
    public void GivenJsonOfMultiContacts_WhenDeserializedBySmartContactConverter_ThenReadObjectsPolymorphously()
    {
        var json = DataSource.GetJsonOfMultiVariantContacts();

        var contacts = JsonConvert.DeserializeObject<List<Contact>>(json, new SmartContactConverter())!;

        Assert.IsType<Contact>(contacts[0]);

        Assert.IsType<SuperContact>(contacts[1]);
        Assert.Equal("0123456", ((SuperContact)contacts[1]).Mobile);

        Assert.IsType<MasterContact>(contacts[2]);
        Assert.Equal("test@test.com", ((MasterContact)contacts[2]).Email);
    }
}