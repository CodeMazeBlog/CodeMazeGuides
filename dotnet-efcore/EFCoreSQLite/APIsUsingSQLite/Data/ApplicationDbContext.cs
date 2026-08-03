using APIsUsingSQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace APIsUsingSQLite.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public virtual DbSet<Product> Products { get; set; }
}
