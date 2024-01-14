using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;

namespace RunningBackgroundTasks.Services.Periodic;

public class PeriodicBackgroundService(
    TimeProvider timeProvider,
    IServiceProvider serviceProvider) : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromHours(24);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(_period, timeProvider);

        using IServiceScope scope = serviceProvider.CreateScope();

        using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        while (!stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            var cutoff = timeProvider.GetUtcNow().AddMonths(-6);

            await context.Clients
                .Where(x => x.LastOrderDate <= cutoff)
                .ExecuteUpdateAsync(setters =>
                    setters.SetProperty(b => b.IsActive, false),
                    cancellationToken: stoppingToken);
        }
    }
}
