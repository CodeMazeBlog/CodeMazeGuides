using System.Text;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Tests.Server;

namespace GraphQLStrawberryShake.Server.IntegrationTests;
public class StrawberryShakeServerIntegrationTests : IClassFixture<WebApiFixture>
{

    private readonly WebApiFixture _fixture;
    private readonly HttpClient _client;

    public StrawberryShakeServerIntegrationTests(WebApiFixture fixture)
    {
        _fixture = fixture;
        _client = _fixture.CreateClient();
    }

    [Fact]
    public async Task WhenCallingGraphql_ThenReturnSeedDataIntegrationTest()
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
