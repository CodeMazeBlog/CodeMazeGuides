using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GlobalErrorHandling.Tests;

public sealed class ExceptionHandlingTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("Development")]
    [InlineData("Production")]
    public async Task AccessViolation_ReturnsProblemDetailsFromTheHandler(string environment)
    {
        var client = factory
            .WithWebHostBuilder(builder => builder.UseEnvironment(environment))
            .CreateClient();

        var response = await client.GetAsync("/api/values", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);

        var body = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        using var problem = JsonDocument.Parse(body);
        Assert.Equal(500, problem.RootElement.GetProperty("status").GetInt32());
        Assert.Equal("Access violation error from the exception handler",
            problem.RootElement.GetProperty("detail").GetString());
        Assert.True(problem.RootElement.TryGetProperty("traceId", out _));
    }

    [Fact]
    public async Task ErrorResponse_DoesNotLeakTheExceptionMessage()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/values", TestContext.Current.CancellationToken);

        var body = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        Assert.DoesNotContain("Violation Exception while accessing the resource.", body);
    }
}
