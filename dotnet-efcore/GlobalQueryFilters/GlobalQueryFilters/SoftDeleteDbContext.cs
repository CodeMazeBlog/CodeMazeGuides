using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters;

public sealed class SoftDeleteDbContext(DbContextOptions<SoftDeleteDbContext> options) : DbContext(options)
{
    public DbSet<SoftDeleteEntity> SoftDeleteEntities { get; private set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SoftDeleteEntity>().HasKey(s => s.Id);
        modelBuilder.Entity<SoftDeleteEntity>().Property(s => s.IsDeleted).IsRequired();
        modelBuilder.Entity<SoftDeleteEntity>().HasQueryFilter(entity => !entity.IsDeleted);
    }
}