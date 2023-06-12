using Microsoft.EntityFrameworkCore;

namespace AggregateDesign.DataAccess;

#nullable disable

public class OrdersDbContext : DbContext
{
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<OrderItemModel> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=orders;Username=postgres;Password=a");
    }
}