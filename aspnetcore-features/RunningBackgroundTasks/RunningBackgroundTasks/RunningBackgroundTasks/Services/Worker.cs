using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services;

public class Worker(TimeProvider timeProvider) : IWorker
{
    private static readonly string[] Names =
        ["John", "Jane", "Alice", "Bob", "Charlie", "David", "Eva", "Frank"];

    public async Task<int> ArchiveOldClientsAsync(
        ApplicationDbContext context,
        CancellationToken cancellationToken = default)
    {
        var cutoff = timeProvider.GetUtcNow().AddMonths(-6);

        var clientsToBeArchived = context.Clients
            .Where(x => x.LastOrderDate <= cutoff)
            .AsAsyncEnumerable()
            .WithCancellation(cancellationToken);

        await foreach (var client in clientsToBeArchived)
        {
            client.IsActive = false;
        }

        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SeedDatabaseAsync(
        ApplicationDbContext context,
        CancellationToken cancellationToken = default)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);

        for (int i = 0; i < 10; i++)
        {
            context.Clients.Add(new()
            {
                Id = Guid.NewGuid(),
                Name = Names[Random.Shared.Next(Names.Length)],
                FirstOrderDate = GenerateRandomDate(),
                LastOrderDate = GenerateRandomDate(),
                IsActive = true,
            });
        }

        return await context.SaveChangesAsync(cancellationToken);
    }

    private static DateTime GenerateRandomDate()
    {
        int year = Random.Shared.Next(2020, 2024);
        int month = Random.Shared.Next(1, 13);
        int day = Random.Shared.Next(1, DateTime.DaysInMonth(year, month) + 1);

        return new DateTime(year, month, day);
    }
}
