using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomHeaderResponse.Models
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            var oneProduct = new Product()
            {
                Brand = "Scoot",
                Description = "Mountain bike",
                Model = "Spark RC",
                Name = "Scoot Spark RC"
            };

            this.Add(oneProduct);

            this.SaveChanges();
        }

        public DbSet<Product> ProductItems { get; set; }
    }
}
