using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Newtonsoft.EnumAsStringTests;

public class CustomSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenEnum_WhenSerializeWithEnumCamelCasePolicy_ThenSerializeAsCamelCaseString()
    {
        var converter = new StringEnumConverter(new CamelCaseNamingStrategy());

        var json = JsonConvert.SerializeObject(Canvas.Poster, converter);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"lightGray\",\"Medium\":\"water\",\"Pen\":{\"Name\":\"Simple\",\"Color\":\"red\"}}", json);
    }

    [Fact]
    public void GivenEnum_WhenDecoratedWithEnumMember_ThenSerializeAsSpecifiedString()
    {
        var controls = new ToggleControl[]
        { 
            new("toggle1", ToggleType.EnableDisable),
            new("toggle2", ToggleType.VisibleHidden)
        };
        var json = SerializeWithStringEnum(controls);

        Assert.Equal("[{\"Name\":\"toggle1\",\"Type\":\"Enable/Disable\"},{\"Name\":\"toggle2\",\"Type\":\"Visible/Hidden\"}]", json);
    }
}