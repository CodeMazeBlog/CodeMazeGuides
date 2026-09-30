using EventTicketing.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Infrastructure;

public sealed class TicketingDbContext(DbContextOptions<TicketingDbContext> options)
    : DbContext(options)
{
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(builder =>
        {
            builder.Property(e => e.Name).HasMaxLength(200);

            builder.HasData(
                new { Id = 1, Name = "Clean Architecture Live", Capacity = 100, TicketsSold = 0 },
                new { Id = 2, Name = "Tiny Jazz Club Night", Capacity = 2, TicketsSold = 0 });
        });
    }
}
