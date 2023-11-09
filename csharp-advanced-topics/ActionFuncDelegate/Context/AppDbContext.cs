using ActionFuncDelegate.Data;
using Microsoft.EntityFrameworkCore;

namespace ActionFuncDelegate.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
