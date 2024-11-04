using APIsUsingSQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace APIsUsingSQLite.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
}
