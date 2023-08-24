using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace JsonSerialization.Newtonsoft.EnumAsStringTests;

public class WebApiUnitTest : UnitTestBase
{
    [Fact]
    public async Task GivenApiApplication_WhenConfiguredWithEnumConverter_ThenSerializeAllEnumsAsStringByDefault()
    {
        await using var api = new WebApplicationFactory<Program>();

        var client = api.CreateClient();
        var poster = await client.GetStringAsync("canvas/poster");
        var schedule = await client.GetStringAsync("canvas/schedule");

        Assert.Equal("{\"name\":\"Poster\",\"backColor\":\"LightGray\",\"medium\":\"Water\",\"pen\":{\"name\":\"Simple\",\"color\":\"Red\"}}", poster);
        Assert.Equal("{\"description\":\"Exhibition\",\"day\":\"Monday\"}", schedule);
    }
}