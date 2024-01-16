using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;

namespace RunningBackgroundTasks.Services.One_off;

public class InitializationBackgroundService(
    IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync(stoppingToken);
    }
}
