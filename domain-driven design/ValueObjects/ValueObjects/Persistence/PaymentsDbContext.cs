using Microsoft.EntityFrameworkCore;
using ValueObjects.Entities;

namespace ValueObjects.Persistence;

public sealed class PaymentsDbContext(DbContextOptions<PaymentsDbContext> options)
    : DbContext(options)
{
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>().ComplexProperty(p => p.Quoted, money =>
        {
            money.Property(m => m.Amount);
            money.Property(m => m.Currency).HasMaxLength(3);
        });
    }
}
