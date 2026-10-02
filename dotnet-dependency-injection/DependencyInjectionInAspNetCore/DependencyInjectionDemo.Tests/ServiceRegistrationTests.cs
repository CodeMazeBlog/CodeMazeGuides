using DependencyInjectionDemo.Models;
using DependencyInjectionDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo.Tests;

public class ServiceRegistrationTests
{
    // The checks ASP.NET Core turns on in the Development environment.
    private static readonly ServiceProviderOptions DevelopmentChecks = new()
    {
        ValidateScopes = true,
        ValidateOnBuild = true
    };

    [Fact]
    public void PlayerOfTheDay_PassesScopeValidation()
    {
        var services = new ServiceCollection();
        services.AddScoped<IPlayerGenerator, PlayerGenerator>();
        services.AddSingleton<PlayerOfTheDay>();

        using var provider = services.BuildServiceProvider(DevelopmentChecks);

        var first = provider.GetRequiredService<PlayerOfTheDay>();
        var second = provider.GetRequiredService<PlayerOfTheDay>();

        Assert.Same(first.Player, second.Player);
    }

    [Fact]
    public void SingletonThatTakesAScopedService_FailsScopeValidation()
    {
        var services = new ServiceCollection();
        services.AddScoped<IPlayerGenerator, PlayerGenerator>();
        services.AddSingleton<CapturingPlayerOfTheDay>();

        var exception = Assert.Throws<AggregateException>(() => services.BuildServiceProvider(DevelopmentChecks));

        Assert.Contains("Cannot consume scoped service", exception.Message);
    }

    // The article's first, wrong PlayerOfTheDay. It lives only here, so the sample never ships the bug.
    private class CapturingPlayerOfTheDay
    {
        public CapturingPlayerOfTheDay(IPlayerGenerator playerGenerator)
        {
            Player = playerGenerator.CreateNewPlayer();
        }

        public Player Player { get; }
    }
}
