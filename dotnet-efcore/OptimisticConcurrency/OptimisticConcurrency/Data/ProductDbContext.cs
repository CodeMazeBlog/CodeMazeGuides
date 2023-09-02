using Microsoft.EntityFrameworkCore;
using OptimisticConcurrency.Model;

namespace OptimisticConcurrency.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext (DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; } = default!;
    }
}
