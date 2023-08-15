using Microsoft.EntityFrameworkCore;
using TestcontainersForDotNetAndDocker.Domain;

namespace TestcontainersForDotNetAndDocker.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cat> Cats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .HasIndex(x => x.Name)
            .IsUnique(true);
    }
}
