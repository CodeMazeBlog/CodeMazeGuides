using AuthApi.Auth.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Tests;

public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public AuthControllerTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task GivenAValidUser_WhenLoggingIn_ThenReturnsJwtToken()
    {
        // Arrange
        var client = _webApplicationFactory.CreateClient();
        var user = new LoginModel("admin", "aDm1n");

        // Act
        var result = await client.PostAsJsonAsync("api/auth", user);
        var content = await result.Content.ReadAsStringAsync();
        var jwtToken = JsonConvert.DeserializeObject<AuthenticationToken>(content);

        // Assert
        Assert.NotNull(jwtToken);
    }

    [Fact]
    public async Task GivenAnInvalidUser_WhenLoggingIn_ThenReturnsUnauthorized()
    {
        // Arrange
        var client = _webApplicationFactory.CreateClient();
        var user = new LoginModel("invalid-user", "invalid-password");

        // Act
        var result = await client.PostAsJsonAsync("api/auth", user);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
    }
}