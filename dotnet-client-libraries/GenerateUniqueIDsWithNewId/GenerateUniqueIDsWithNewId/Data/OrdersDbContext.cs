using GenerateUniqueIDsWithNewId.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GenerateUniqueIDsWithNewId.Data;

public class OrdersDbContext(DbContextOptions<OrdersDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Order> Orders { get; set; }
}
