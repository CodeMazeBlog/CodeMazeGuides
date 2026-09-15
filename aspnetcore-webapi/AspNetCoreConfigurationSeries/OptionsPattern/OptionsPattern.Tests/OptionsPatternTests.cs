using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;
using ProjectConfigurationDemo.Services;

namespace OptionsPattern.Tests;

public class OptionsPatternTests
{
    private static IConfiguration BuildConfiguration() =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Pages:HomePage:WelcomeMessage"] = "Welcome to the Home Page",
                ["Pages:HomePage:ShowWelcomeMessage"] = "true",
                ["Pages:HomePage:Color"] = "red",
                ["Pages:HomePage:UseRandomTitleColor"] = "true",
                ["Pages:ProductPage:WelcomeMessage"] = "Welcome to the Product Page",
                ["Pages:ProductPage:ShowWelcomeMessage"] = "true",
                ["Pages:ProductPage:Color"] = "black",
                ["Pages:ProductPage:UseRandomTitleColor"] = "false"
            })
            .Build();

    private static ServiceProvider BuildNamedOptionsProvider()
    {
        var configuration = BuildConfiguration();
        var services = new ServiceCollection();

        services.Configure<TitleConfiguration>("HomePage", configuration.GetSection("Pages:HomePage"));
        services.Configure<TitleConfiguration>("ProductPage", configuration.GetSection("Pages:ProductPage"));
        services.AddSingleton<ITitleColorService, TitleColorService>();

        return services.BuildServiceProvider();
    }

    [Fact]
    public void GivenAnUnnamedRegistration_WhenIOptionsValueIsRead_ThenTheSectionIsBoundToTheClass()
    {
        var services = new ServiceCollection();
        services.Configure<TitleConfiguration>(BuildConfiguration().GetSection("Pages:HomePage"));

        var options = services.BuildServiceProvider().GetRequiredService<IOptions<TitleConfiguration>>();

        Assert.Equal("Welcome to the Home Page", options.Value.WelcomeMessage);
        Assert.True(options.Value.ShowWelcomeMessage);
        Assert.Equal("red", options.Value.Color);
    }

    [Fact]
    public void GivenTwoNamedRegistrations_WhenEachIsRead_ThenOneClassCarriesTwoDifferentInstances()
    {
        using var provider = BuildNamedOptionsProvider();
        var monitor = provider.GetRequiredService<IOptionsMonitor<TitleConfiguration>>();

        var homePage = monitor.Get("HomePage");
        var productPage = monitor.Get("ProductPage");

        Assert.Equal("Welcome to the Home Page", homePage.WelcomeMessage);
        Assert.Equal("Welcome to the Product Page", productPage.WelcomeMessage);
        Assert.True(homePage.UseRandomTitleColor);
        Assert.False(productPage.UseRandomTitleColor);
    }

    [Fact]
    public void GivenAPageThatDoesNotUseARandomColor_WhenTheColorIsRequested_ThenTheConfiguredColorComesBack()
    {
        using var provider = BuildNamedOptionsProvider();
        var titleColorService = provider.GetRequiredService<ITitleColorService>();

        var color = titleColorService.GetTitleColor("ProductPage");

        Assert.Equal("black", color);
    }

    // This is the test that would have caught 'random.Next(7)' over eight colours:
    // "pink" sits at index 7 and was unreachable.
    [Fact]
    public void GivenAPageThatUsesARandomColor_WhenTheColorIsRequestedManyTimes_ThenEveryColorCanBeSelected()
    {
        using var provider = BuildNamedOptionsProvider();
        var titleColorService = provider.GetRequiredService<ITitleColorService>();
        string[] expected = ["red", "green", "blue", "black", "purple", "yellow", "brown", "pink"];

        var seen = new HashSet<string>();
        for (var i = 0; i < 20_000; i++)
            seen.Add(titleColorService.GetTitleColor("HomePage"));

        Assert.Equal(expected.Order(), seen.Order());
    }
}
