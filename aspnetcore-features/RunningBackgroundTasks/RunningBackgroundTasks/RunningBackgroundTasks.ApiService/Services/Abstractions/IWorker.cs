using RunningBackgroundTasks.Domain;

namespace RunningBackgroundTasks.ApiService.Services.Abstractions;

public interface IWorker
{
    Task<int> ArchiveOldClientsAsync(ApplicationDbContext context, CancellationToken cancellationToken = default);
    Task<int> SeedDatabaseAsync(ApplicationDbContext context, CancellationToken cancellationToken = default);
}