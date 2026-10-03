using Microsoft.AspNetCore.Mvc.Testing;

namespace DependencyInjectionDemo.Tests;

// WebApplicationFactory runs the app in the Development environment,
// so the container's ValidateScopes and ValidateOnBuild checks run at startup too.
public class GamePageTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetGame_ShowsMinsc()
    {
        var client = factory.CreateClient();

        var page = await client.GetStringAsync("/Game", TestContext.Current.CancellationToken);

        Assert.Contains("Name: Minsc", page);
    }
}
