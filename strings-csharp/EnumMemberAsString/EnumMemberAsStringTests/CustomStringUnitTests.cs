using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

public class CustomStringUnitTests
{
    [Fact]
    public void WhenMemberHasEnumMemberAttribute_ThenSystemTextJsonIgnoresIt()
    {
        var json = JsonSerializer.Serialize(new Trip { Name = "a", Region = Region.NorthAmerica });

        Assert.Equal("{\"Name\":\"a\",\"Region\":\"NorthAmerica\"}", json);
    }

    [Fact]
    public void WhenMemberHasJsonStringEnumMemberName_ThenSystemTextJsonUsesIt()
    {
        var json = JsonSerializer.Serialize(new Trip { Name = "b", Region = Region.AsiaPacific });

        Assert.Equal("{\"Name\":\"b\",\"Region\":\"asia-pacific\"}", json);
    }

    [Fact]
    public void WhenMemberHasDescription_ThenReflectionReturnsIt()
    {
        var description = typeof(Region)
            .GetField(nameof(Region.NorthAmerica))?
            .GetCustomAttribute<DescriptionAttribute>()?
            .Description;

        Assert.Equal("North America", description);
    }
}
