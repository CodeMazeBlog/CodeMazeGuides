using Xunit;
using JsonToXmlBackAndForth.Newtonsoft;
using Newtonsoft.Json;

namespace JsonToXmlBackAndForth.Tests;

public class NewtonsoftJsonUnitTest
{
    [Fact]
    public void GivenXml_WhenUsingXmlToJson_ThenProducesJson()
    {
        var xml = MovieStats.Xml;

        var json = JsonXmlUtils.XmlToJson(xml);
        
        var expectedJson = @"{""?xml"":{""@version"":""1.0""},""SquidGame"":{""Genre"":""Thriller"",""Rating"":{""@Type"":""Imdb"",""#text"":""8.1""},""Stars"":[""Lee Jung-jae"",""Park Hae-soo""],""Budget"":null}}";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenXml_WhenUsingXmlDocumentToJson_ThenProducesJson()
    {
        var xml = MovieStats.Xml;

        var json = JsonXmlUtils.XmlDocumentToJson(xml);

        var expectedJson = @"{""?xml"":{""@version"":""1.0""},""SquidGame"":{""Genre"":""Thriller"",""Rating"":{""@Type"":""Imdb"",""#text"":""8.1""},""Stars"":[""Lee Jung-jae"",""Park Hae-soo""],""Budget"":null}}";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenXml_WhenUsingXmlToPrettyJson_ThenProducesIndentedJson()
    {
        var xml = MovieStats.Xml;

        var json = JsonXmlUtils.XmlToPrettyJson(xml);

        var expectedJson = @"{
  ""?xml"": {
    ""@version"": ""1.0""
  },
  ""SquidGame"": {
    ""Genre"": ""Thriller"",
    ""Rating"": {
      ""@Type"": ""Imdb"",
      ""#text"": ""8.1""
    },
    ""Stars"": [
      ""Lee Jung-jae"",
      ""Park Hae-soo""
    ],
    ""Budget"": null
  }
}".ReplaceLineEndings();

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenXml_WhenUsingXmlToJsonWithoutRoot_ThenProducesJsonOmittingTheRoot()
    {
        var xml = @"
        <SquidGame>
          <Name>Squid Game</Name>
          <Genre>Thriller</Genre>
        </SquidGame>";

        var json = JsonXmlUtils.XmlToJsonWithoutRoot(xml);

        var expectedJson = @"{""Name"":""Squid Game"",""Genre"":""Thriller""}";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenXmlWithSingleStars_WhenUsingXmlToJson_ThenProducesJsonWithPlainStarsString()
    {
        var xml = @"<?xml version='1.0'?>
    <SquidGame>
      <Genre>Thriller</Genre>
      <Rating Type='Imdb'>8.1</Rating>
      <Stars>Lee Jung-jae</Stars>
      <Budget />
    </SquidGame>";

        var json = JsonXmlUtils.XmlToJson(xml);

        var expectedJson = @"{""?xml"":{""@version"":""1.0""},""SquidGame"":{""Genre"":""Thriller"",""Rating"":{""@Type"":""Imdb"",""#text"":""8.1""},""Stars"":""Lee Jung-jae"",""Budget"":null}}";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenXmlWithSingleStarsAndArrayFlag_WhenUsingXmlToJson_ThenProducesJsonWithStarsArray()
    {
        var xml = @"<?xml version='1.0'?>
    <SquidGame xmlns:json='http://james.newtonking.com/projects/json'>
      <Genre>Thriller</Genre>
      <Rating Type='Imdb'>8.1</Rating>
      <Stars json:Array='true'>Lee Jung-jae</Stars>
      <Budget />
    </SquidGame>";

        var json = JsonXmlUtils.XmlToJson(xml);

        var expectedJson = @"{""?xml"":{""@version"":""1.0""},""SquidGame"":{""Genre"":""Thriller"",""Rating"":{""@Type"":""Imdb"",""#text"":""8.1""},""Stars"":[""Lee Jung-jae""],""Budget"":null}}";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenXmlWithSingleStars_WhenUsingXmlToJsonWithJsonArrayFlag_ThenProducesJsonWithStarsArray()
    {
        var xml = @"<?xml version='1.0'?>
    <SquidGame>
      <Genre>Thriller</Genre>
      <Rating Type='Imdb'>8.1</Rating>
      <Stars>Lee Jung-jae</Stars>
      <Budget />
    </SquidGame>";

        var json = JsonXmlUtils.XmlToJsonWithJsonArrayFlag(xml);

        var expectedJson = @"{""?xml"":{""@version"":""1.0""},""SquidGame"":{""Genre"":""Thriller"",""Rating"":{""@Type"":""Imdb"",""#text"":""8.1""},""Stars"":[""Lee Jung-jae""],""Budget"":null}}";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void GivenJsonWithRoot_WhenUsingJsonToXml_ThenProducesXmlSuccessfully()
    {
        var json = MovieStats.Json;

        var xml = JsonXmlUtils.JsonToXml(json);

        var expectedXml = @"<?xml version=""1.0""?>
<SquidGame>
  <Genre>Thriller</Genre>
  <Rating Type=""Imdb"">8.1</Rating>
  <Stars>Lee Jung-jae</Stars>
  <Stars>Park Hae-soo</Stars>
  <Budget />
</SquidGame>".ReplaceLineEndings();

        Assert.Equal(expectedXml, xml);
    }

    [Fact]
    public void GivenJsonWithoutRoot_WhenUsingJsonToXml_ThenFails()
    {
        var json = @"{""Name"":""Squid Game"",""Genre"":""Thriller""}";

        Assert.ThrowsAny<JsonSerializationException>(() => JsonXmlUtils.JsonToXml(json));
    }

    [Fact]
    public void GivenJsonWithoutRoot_WhenUsingJsonToXmlWithExplicitRoot_ThenProducesXmlWithSuppliedRoot()
    {
        var json = @"{""Name"":""Squid Game"",""Genre"":""Thriller""}";

        var xml = JsonXmlUtils.JsonToXmlWithExplicitRoot(json, "Movie");

        var expectedXml = @"<?xml version=""1.0""?>
<Movie>
  <Name>Squid Game</Name>
  <Genre>Thriller</Genre>
</Movie>".ReplaceLineEndings();

        Assert.Equal(expectedXml, xml);
    }
}