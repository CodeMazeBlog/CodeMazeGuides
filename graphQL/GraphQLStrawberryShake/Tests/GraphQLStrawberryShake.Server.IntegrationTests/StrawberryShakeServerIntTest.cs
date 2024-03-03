using System.Text;
using API.IntegrationTests;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace GraphQLStrawberryShake.Server.IntegrationTests;
public class StrawberryShakeServerIntegrationTest : IClassFixture<WebApiFixture>
{

    private readonly WebApiFixture _fixture;
    private readonly HttpClient _client;

    public StrawberryShakeServerIntegrationTest(WebApiFixture fixture)
    {
        _fixture = fixture;
        _client = _fixture.CreateClient();
    }

    [Fact]
    public async Task WhenCallingGraphql_ThenReturnSeedData()
    {
        var query = new StringContent(
            @"{ ""query"": ""{ shippingContainers { id name space { length width height volume } } }"" }",
            Encoding.UTF8,
            "application/json");

        var response = await _client.PostAsync("/graphql", query);

        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var responseJson = JObject.Parse(responseString);

        responseJson.SelectToken("data.shippingContainers").Should().NotBeNull();
        responseString.Should().Contain("id");
        responseString.Should().Contain("name");
    }
}
