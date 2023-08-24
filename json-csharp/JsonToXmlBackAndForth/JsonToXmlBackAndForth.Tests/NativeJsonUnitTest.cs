using JsonToXmlBackAndForth.Native;
using Xunit;

namespace JsonToXmlBackAndForth.Tests;

public class NativeJsonUnitTest
{
    [Fact]
    public void GivenJson_WhenUsingJsonToXml_ThenProducesXml()
    {
        var xml = JsonXmlUtils.JsonToXml(MovieStats.Json);

        var expectedXml = @"<?xml version=""1.0"" encoding=""utf-16""?><SquidGame><Genre>Thriller</Genre><Rating Type=""Imdb"">8.1</Rating><Stars>Lee Jung-jae</Stars><Stars>Park Hae-soo</Stars></SquidGame>";

        Assert.Equal(expectedXml, xml);
    }

    [Fact]
    public void GivenJson_WhenUsingXmlToJson_ThenProducesJson()
    {
        var json = JsonXmlUtils.XmlToJson(MovieStats.Xml);

        var expectedJson = @"{""SquidGame"":{""Genre"":""Thriller"",""Rating"":{""@Type"":""Imdb"",""#text"":""8.1""},""Stars"":[""Lee Jung-jae"",""Park Hae-soo""],""Budget"":{}}}";

        Assert.Equal(expectedJson, json);
    }
}