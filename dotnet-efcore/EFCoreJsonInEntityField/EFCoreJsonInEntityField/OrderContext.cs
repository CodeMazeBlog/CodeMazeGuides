using EFCoreJsonInEntityField.Mapping;
using EFCoreJsonInEntityField.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreJsonInEntityField
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());        
        }

        public DbSet<Order> Orders { get; set; }
    }
}
