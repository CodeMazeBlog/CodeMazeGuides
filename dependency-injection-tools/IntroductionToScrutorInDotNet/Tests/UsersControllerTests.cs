using System.Net;
using System.Net.Http.Json;
using IntroductionToScrutorInDotNet.Entities;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class UsersControllerTests
{
    private readonly HttpClient _httpClient;

    public UsersControllerTests()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenUserId_WhenGettingUser_ThenUserIsReturned()
    {
        var userId = 1;
        var response = await _httpClient.GetAsync($"/Users/{userId}");

        var returnedUser = await response.Content.ReadFromJsonAsync<User>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equivalent(new
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        }, returnedUser);
    }

    [Fact]
    public async Task WhenGettingListOfUsers_ThenListOfUsersIsReturned()
    {
        var response = await _httpClient.GetAsync($"/Users");

        var returnedUsers = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(2, returnedUsers!.Count());
    }
}