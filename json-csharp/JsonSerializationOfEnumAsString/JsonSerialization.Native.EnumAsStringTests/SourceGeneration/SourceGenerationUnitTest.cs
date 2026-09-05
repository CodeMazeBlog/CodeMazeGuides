using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Native.EnumAsStringTests.SourceGeneration;

public class SourceGenerationUnitTest
{
    [Fact]
    public void GivenSourceGeneratedContext_WhenUseStringEnumConverterIsSet_ThenSerializeAllEnumsAsString()
    {
        var json = JsonSerializer.Serialize(Canvas.Poster, CanvasContext.Default.Canvas);

        Assert.Equal("{\"Name\":\"Poster\",\"BackColor\":\"LightGray\",\"Medium\":\"Water\",\"Pen\":{\"Name\":\"Simple\",\"Color\":\"Red\"}}", json);
    }
}
