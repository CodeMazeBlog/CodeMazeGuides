using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Native.EnumAsStringTests;

public class DefaultSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenEnum_WhenTreatedBySerializer_ThenByDefaultSerializeAsInteger()
    {
        var json = Serialize(Canvas.Poster);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":1,\"Medium\":0,\"Pen\":{\"Name\":\"Simple\",\"Color\":3}}", json);
    }
}