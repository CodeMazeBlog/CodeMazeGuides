#nullable disable
using Microsoft.EntityFrameworkCore;
using Producer.Data;

public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext (DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
}
