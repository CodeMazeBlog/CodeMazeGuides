using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public class PlayerOfTheDay
{
    public PlayerOfTheDay(IServiceScopeFactory scopeFactory)
    {
        using var scope = scopeFactory.CreateScope();
        var playerGenerator = scope.ServiceProvider.GetRequiredService<IPlayerGenerator>();

        Player = playerGenerator.CreateNewPlayer();
    }

    public Player Player { get; }
}
