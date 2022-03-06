using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Newtonsoft.EnumAsStringTests;

public class FlagEnumSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenFlagEnum_WhenSerializeByDefault_ThenSerializeAsCombinedNumber()
    {
        var style = TextStyle.Bold | TextStyle.Italic | TextStyle.Underline;

        var json = Serialize(new { Format = style });

        Assert.Equal("{\"Format\":7}", json);
    }

    [Fact]
    public void GivenFlagEnum_WhenSerializeWithEnumConverter_ThenSerializeAsCsvString()
    {
        var style = TextStyle.Bold | TextStyle.Italic | TextStyle.Underline;

        var json = SerializeWithStringEnum(new { Format = style });

        Assert.Equal("{\"Format\":\"Bold, Italic, Underline\"}", json);
    }
}