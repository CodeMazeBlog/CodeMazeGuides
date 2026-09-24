using EventTicketing.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventTicketing.Infrastructure.Persistence;

public static class DatabaseSeeder
{
    public static async Task SeedDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TicketingDbContext>();

        await dbContext.Database.EnsureCreatedAsync();

        if (!await dbContext.Events.AnyAsync())
        {
            dbContext.Events.AddRange(
                Event.Create("Clean Architecture Live", capacity: 100),
                Event.Create("Tiny Jazz Club Night", capacity: 2));

            await dbContext.SaveChangesAsync();
        }
    }
}
