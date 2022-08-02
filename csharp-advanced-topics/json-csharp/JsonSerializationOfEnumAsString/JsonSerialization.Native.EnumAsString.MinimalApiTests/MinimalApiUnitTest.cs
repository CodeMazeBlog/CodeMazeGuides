using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace JsonSerialization.Native.EnumAsString.MinimalApiTests;

public class MinimalApiUnitTest
{
    [Fact]
    public async Task GivenMinimalApiApp_WhenConfiguredWithEnumConverter_ThenSerializeAllEnumsAsStringByDefault()
    {
        await using var api = new WebApplicationFactory<Program>();

        var client = api.CreateClient();
        var poster = await client.GetStringAsync("/poster");
        var schedule = await client.GetStringAsync("/schedule");

        Assert.Equal("{\"name\":\"Poster\",\"backColor\":\"LightGray\",\"medium\":\"Water\",\"pen\":{\"name\":\"Simple\",\"color\":\"Red\"}}", poster);
        Assert.Equal("{\"description\":\"Exhibition\",\"day\":\"Monday\"}", schedule);
    }
}