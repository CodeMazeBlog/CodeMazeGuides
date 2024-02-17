using InjectDbContextIntoIHostedService.Data;
using Microsoft.EntityFrameworkCore;

namespace InjectDbContextIntoIHostedService.Services;

public class CatsSeedingService(IDbContextFactory<CatsDbContext> contextFactory)
    : IHostedService
{
    private static readonly int MaxAge = 15;
    private static readonly string[] Names =
        ["Whiskers", "Luna", "Simba", "Bella", "Oliver", "Shadow", "Gizmo", "Cleo", "Jasper", "Mocha"];

    public async Task StartAsync(CancellationToken cancellationToken)
    {        
        using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        await context.Database.EnsureCreatedAsync(cancellationToken);

        for (int i = 0; i < 50; i++)
        {
            context.Cats.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = Names[Random.Shared.Next(Names.Length)],
                Age = Random.Shared.Next(1, MaxAge)
            });
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
