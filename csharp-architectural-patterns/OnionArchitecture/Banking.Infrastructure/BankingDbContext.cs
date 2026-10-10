using Banking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure;

public sealed class BankingDbContext(DbContextOptions<BankingDbContext> options)
    : DbContext(options)
{
    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(builder =>
        {
            builder.Property(a => a.Owner).HasMaxLength(100);

            builder.HasData(
                new { Id = 1, Owner = "Anna Smith", Balance = 100m },
                new { Id = 2, Owner = "Mark Jones", Balance = 20m });
        });
    }
}
