using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters;

public sealed class SoftDeleteDbContext(DbContextOptions<SoftDeleteDbContext> options) : DbContext(options)
{
    public DbSet<Child> Children { get; private set; }
    public DbSet<SoftDeleteEntity> SoftDeleteEntities { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SoftDeleteEntity>().HasKey(s => s.Id);
        modelBuilder.Entity<SoftDeleteEntity>().Property(s => s.IsDeleted).IsRequired();
        modelBuilder.Entity<SoftDeleteEntity>().HasQueryFilter(entity => !entity.IsDeleted);
        modelBuilder.Entity<SoftDeleteEntity>().HasMany(s => s.Children).WithOne(c => c.Parent).IsRequired();
        
        modelBuilder.Entity<Child>().HasKey(c => c.Id);
        modelBuilder.Entity<Child>().HasQueryFilter(c => !c.Parent.IsDeleted);

    }
}