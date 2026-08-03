using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreComplexTypes;

public class AppDbContext() : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var solutionDirectory
            = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
        var dbPath = Path.Combine(solutionDirectory, "ComplexTypesDatabase.DB");

        optionsBuilder.UseSqlite($"DataSource = {dbPath}")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<User>().ComplexProperty(u => u.Address);
}