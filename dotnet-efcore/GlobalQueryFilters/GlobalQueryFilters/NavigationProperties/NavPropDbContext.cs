using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters;

public sealed class NavPropDbContext(DbContextOptions<NavPropDbContext> options) : DbContext(options)
{
    public DbSet<ChildEntity> Children { get; private set; } = null!;
    public DbSet<ParentEntity> ParentEntities { get; private set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParentEntity>().HasKey(s => s.Id);
        modelBuilder.Entity<ParentEntity>().Property(s => s.IsDeleted).IsRequired();
        modelBuilder.Entity<ParentEntity>().HasQueryFilter(entity => !entity.IsDeleted);
        modelBuilder.Entity<ParentEntity>().HasMany(s => s.Children).WithOne(c => c.Parent).IsRequired();

        modelBuilder.Entity<ChildEntity>().HasKey(c => c.Id);
    }
}