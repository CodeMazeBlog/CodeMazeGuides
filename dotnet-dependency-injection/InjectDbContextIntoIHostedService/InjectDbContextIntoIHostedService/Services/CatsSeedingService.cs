using InjectDbContextIntoIHostedService.Data;

namespace InjectDbContextIntoIHostedService.Services;

public class CatsSeedingService(IServiceScopeFactory scopeFactory)
    : IHostedService
{
    private static readonly int _maxAge = 15;
    private static readonly string[] _names =
        ["Whiskers", "Luna", "Simba", "Bella", "Oliver", "Shadow", "Gizmo", "Cleo", "Jasper", "Mocha"];

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CatsDbContext>();

        await context.Database.EnsureCreatedAsync(cancellationToken);

        context.Cats.AddRange(Enumerable.Range(1, 50)
            .Select(_ => new Cat
            {
                Id = Guid.NewGuid(),
                Name = _names[Random.Shared.Next(_names.Length)],
                Age = Random.Shared.Next(1, _maxAge)
            }));

        await context.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
