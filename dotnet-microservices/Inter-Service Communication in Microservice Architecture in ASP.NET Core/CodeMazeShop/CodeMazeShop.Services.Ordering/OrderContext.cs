using CodeMazeShop.Services.Ordering.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeMazeShop.Services.Ordering
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        public DbSet<ShippingDetails> ShippingDetails { get; set; }
    }
}
