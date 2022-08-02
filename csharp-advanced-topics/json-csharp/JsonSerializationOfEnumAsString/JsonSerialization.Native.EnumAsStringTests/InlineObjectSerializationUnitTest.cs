using JsonSerialization.EnumAsString.Models;
using System;

namespace JsonSerialization.Native.EnumAsStringTests;

public class InlineObjectSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenObject_WhenSerializeWithEnumConverter_ThenContainsAllEnumInstancesAsString()
    {
        var poster = SerializeWithStringEnum(Canvas.Poster);
        var schedule = SerializeWithStringEnum(new { Description = "Exhibition", Day = DayOfWeek.Monday });

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"LightGray\",\"Medium\":\"Water\",\"Pen\":{\"Name\":\"Simple\",\"Color\":\"Red\"}}", poster);

        Assert.Equal("{\"Description\":\"Exhibition\",\"Day\":\"Monday\"}", schedule);
    }
}