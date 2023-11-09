namespace JsonSerialization.Native.EnumAsStringTests.TypeSelection;

public class CustomSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenEnumType_WhenDecoratedWithEnumConverter_ThenSerializeAllInstancesAsString()
    {
        var json = Serialize(Canvas.Poster);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"LightGray\",\"Medium\":0,\"Pen\":{\"Name\":\"Simple\",\"Color\":\"Red\"}}", json);
    }
}