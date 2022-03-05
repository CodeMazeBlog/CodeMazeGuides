using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Native.EnumAsStringTests;

public class InlineObjectSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenObject_WhenSerializeWithEnumConverter_ThenContainsAllEnumInstancesAsString()
    {
        var json = SerializeWithStringEnum(Canvas.Poster);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"LightGray\",\"Medium\":\"Water\",\"Pen\":{\"Name\":\"Simple\",\"Color\":\"Red\"}}", json);
    }
}