using Banking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure;

public sealed class BankDbContext(DbContextOptions<BankDbContext> options)
    : DbContext(options)
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Transfer> Transfers => Set<Transfer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new { Id = 1, Owner = "Alice", Balance = 100m },
            new { Id = 2, Owner = "Bob", Balance = 50m });

        modelBuilder.Entity<Transfer>()
            .HasIndex(t => t.Reference)
            .IsUnique();
    }
}
