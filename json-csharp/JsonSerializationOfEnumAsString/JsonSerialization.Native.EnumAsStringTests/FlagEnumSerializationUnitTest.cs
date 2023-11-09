using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Native.EnumAsStringTests;

public class FlagEnumSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenFlagEnum_WhenSerializeByDefault_ThenSerializeAsCombinedNumber()
    {
        var styles = TextStyles.Bold | TextStyles.Italic | TextStyles.Underline;

        var json = Serialize(new { Format = styles });

        Assert.Equal("{\"Format\":7}", json);
    }

    [Fact]
    public void GivenFlagEnum_WhenSerializeWithEnumConverter_ThenSerializeAsCsvString()
    {
        var styles = TextStyles.Bold | TextStyles.Italic | TextStyles.Underline;

        var json = SerializeWithStringEnum(new { Format = styles });

        Assert.Equal("{\"Format\":\"Bold, Italic, Underline\"}", json);
    }
}