using CookieAuthenticationWithAngular.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Xunit;

namespace CookieAuthenticationWithAngular.Tests;

public class ApiTest
{
    string signInApi = "api/auth/signin";
    string userApi = "api/auth/user";
    string signOutApi = "api/auth/signout";
    [Fact]
    public async Task WhenCallingUnauthorizedEndpoint_ThenReturn401()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetAsync(userApi);

        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task WhenCallingSignInApi_WithInvalidCredentials_ShouldFail()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.PostAsJsonAsync(signInApi, new SignInRequest("invalid-email", "invalid-password"));
        var result = await response.Content.ReadFromJsonAsync<Response>();

        Assert.False(result?.IsSuccess);
    }

    [Fact]
    public async Task WhenCallingSignInApi_WithValidCredentials_ShouldReturnCookies()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.PostAsJsonAsync(signInApi, new SignInRequest("user1@test.com", "user1"));
        var result = await response.Content.ReadFromJsonAsync<Response>();

        Assert.True(result?.IsSuccess);

        // The response should contain the cookie header
        var cookieHeader = response.Headers.GetValues("Set-Cookie").First();

        Assert.Contains(".AspNetCore.Cookies=", cookieHeader);

        // When protected endpoint is called with this cookie, it should succeed
        client.DefaultRequestHeaders.Add("Cookie", cookieHeader);
        var userResult = await client.GetAsync(userApi);

        Assert.True(userResult.IsSuccessStatusCode);

        // When signout is called, it should return expired cookie
        var signOutResult = await client.GetAsync(signOutApi);

        Assert.True(signOutResult.IsSuccessStatusCode);

        var signOutCookie = signOutResult.Headers.GetValues("Set-Cookie").First();

        Assert.Contains(signOutCookie, ".AspNetCore.Cookies=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/; samesite=lax; httponly");

        // Again if the user endpoint is called with the new signout cookie, then it should fail as unauthorized
        client.DefaultRequestHeaders.Remove("Cookie");
        client.DefaultRequestHeaders.Add("Cookie", signOutCookie);
        var userResultUnAuthorized = await client.GetAsync(userApi);

        Assert.Equal(System.Net.HttpStatusCode.Unauthorized, userResultUnAuthorized.StatusCode);
    }
}