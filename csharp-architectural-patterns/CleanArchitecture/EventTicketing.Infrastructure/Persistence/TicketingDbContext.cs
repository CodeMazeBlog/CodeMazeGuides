using EventTicketing.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Infrastructure.Persistence;

public sealed class TicketingDbContext(DbContextOptions<TicketingDbContext> options)
    : DbContext(options)
{
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(200);
        });
    }
}
