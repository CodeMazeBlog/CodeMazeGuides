namespace ReadArraysFromAppSettingsTests;

public class ReatArraysFromAppSettingsUnitTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public ReatArraysFromAppSettingsUnitTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task WhenSendingAGetRequestForUsers_ThenReturnListOfUsers()
    {
        // arrange
        var client = _webApplicationFactory.CreateClient();

        // act
        var result = await client.GetFromJsonAsync<List<User>>(Endpoints.GetUsersEndpointName);

        // assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task WhenSendingAGetRequestForUsers_AndV2ApiIsUsed_ThenReturnListOfUsers()
    {
        // arrange
        var client = _webApplicationFactory.CreateClient();

        // act
        var result = await client.GetFromJsonAsync<List<User>>(Endpoints.GetUsersV2EndpointName);

        // assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task WhenSendingAGetRequestForGroupMembers_ThenReturnListOfMembersInTheGroups()
    {
        // arrange
        var client = _webApplicationFactory.CreateClient();

        // act
        var result = await client.GetFromJsonAsync<List<Member>>(Endpoints.GetGroupMembersEndpointName);

        // assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}