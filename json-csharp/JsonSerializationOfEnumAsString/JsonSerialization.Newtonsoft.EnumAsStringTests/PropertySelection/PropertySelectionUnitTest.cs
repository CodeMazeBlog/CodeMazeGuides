namespace JsonSerialization.Newtonsoft.EnumAsStringTests.PropertySelection;

public class PropertySelectionUnitTest : UnitTestBase
{
    [Fact]
    public void GivenEnumProperty_WhenDecoratedWithEnumConverter_ThenSerializeAsString()
    {
        var json = Serialize(Canvas.Poster);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"LightGray\",\"Medium\":0,\"Pen\":{\"Name\":\"Simple\",\"Color\":3}}", json);
    }
}