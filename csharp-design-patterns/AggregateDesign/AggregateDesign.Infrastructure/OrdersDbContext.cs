using AggregateDesign.Domain;
using Microsoft.EntityFrameworkCore;

namespace AggregateDesign.Infrastructure;

public sealed class OrdersDbContext(DbContextOptions<OrdersDbContext> options)
    : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .OwnsMany(o => o.Items, item => item.HasKey("OrderId", nameof(OrderItem.Name)));
    }
}
