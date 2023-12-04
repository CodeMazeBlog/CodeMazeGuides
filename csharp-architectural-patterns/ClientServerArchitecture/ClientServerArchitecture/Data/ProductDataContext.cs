using ClientServerArchitecture.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientServerArchitecture.Data;

public class ProductDataContext : DbContext
{
    public ProductDataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
