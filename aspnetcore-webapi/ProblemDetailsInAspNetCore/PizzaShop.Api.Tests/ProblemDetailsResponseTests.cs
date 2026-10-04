using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PizzaShop.Api.Tests;

public sealed class ProblemDetailsResponseTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task KnownPizza_ReturnsStock()
    {
        var response = await factory.CreateClient()
            .GetAsync("/api/pizzas/Margherita", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UnknownPizza_Returns404WithErrorCodeInTitle()
    {
        var response = await factory.CreateClient()
            .GetAsync("/api/pizzas/Hawaiian", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);

        using var problem = await ReadJsonAsync(response);
        Assert.Equal("Pizza.NotFound", problem.RootElement.GetProperty("title").GetString());
        Assert.Equal(404, problem.RootElement.GetProperty("status").GetInt32());
        Assert.Equal("/api/pizzas/Hawaiian", problem.RootElement.GetProperty("instance").GetString());
        Assert.True(problem.RootElement.TryGetProperty("traceId", out _));
    }

    [Fact]
    public async Task SoldOutPizza_Returns409Problem()
    {
        var response = await factory.CreateClient().PostAsJsonAsync(
            "/api/pizzas/Diavola/orders", new { quantity = 3 }, TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);

        using var problem = await ReadJsonAsync(response);
        Assert.Equal("Pizza.SoldOut", problem.RootElement.GetProperty("title").GetString());
    }

    [Fact]
    public async Task InvalidQuantity_Returns400WithErrors()
    {
        var response = await factory.CreateClient().PostAsJsonAsync(
            "/api/pizzas/Margherita/orders", new { quantity = 0 }, TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        using var problem = await ReadJsonAsync(response);
        Assert.True(problem.RootElement.GetProperty("errors").TryGetProperty("Quantity", out _));
    }

    [Fact]
    public async Task UnknownRoute_Returns404ProblemFromStatusCodePages()
    {
        var response = await factory.CreateClient()
            .GetAsync("/api/pizza/Margherita", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
    }

    private static async Task<JsonDocument> ReadJsonAsync(HttpResponseMessage response) =>
        JsonDocument.Parse(await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken));
}
