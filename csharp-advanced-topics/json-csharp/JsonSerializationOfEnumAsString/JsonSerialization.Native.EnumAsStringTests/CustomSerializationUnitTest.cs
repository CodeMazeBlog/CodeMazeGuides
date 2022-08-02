using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Native.EnumAsStringTests;

public class CustomSerializationUnitTest : UnitTestBase
{
    [Fact]
    public void GivenEnum_WhenSerializeWithPropertyCamelCasePolicy_ThenDoesNotCamelCaseEnumValues()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        options.Converters.Add(new JsonStringEnumConverter());

        var json = JsonSerializer.Serialize(Canvas.Poster, options);

        Assert.Equal("{\"name\":\"Poster\",\"backColor\":\"LightGray\",\"medium\":\"Water\",\"pen\":{\"name\":\"Simple\",\"color\":\"Red\"}}", json);
    }

    [Fact]
    public void GivenEnum_WhenSerializeWithEnumCamelCasePolicy_ThenCamelCaseEnumValues()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        var json = JsonSerializer.Serialize(Canvas.Poster, options);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"lightGray\",\"Medium\":\"water\",\"Pen\":{\"Name\":\"Simple\",\"Color\":\"red\"}}", json);
    }

    [Fact]
    public void GivenEnum_WhenDecoratedWithEnumMember_ThenIgnoresEnumMemberOnSerialize()
    {
        var controls = new ToggleControl[]
        {
            new("toggle1", ToggleType.EnableDisable),
            new("toggle2", ToggleType.VisibleHidden)
        };
        var json = SerializeWithStringEnum(controls);

        Assert.Equal("[{\"Name\":\"toggle1\",\"Type\":\"EnableDisable\"},{\"Name\":\"toggle2\",\"Type\":\"VisibleHidden\"}]", json);
    }
}