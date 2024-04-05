using Microsoft.EntityFrameworkCore;

namespace GraphQLStrawberryShake.Server;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ShippingContainer> ShippingContainers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShippingContainer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.OwnsOne(e => e.Space, space =>
            {
                space.Property(e => e.Length).IsRequired();
                space.Property(e => e.Width).IsRequired();
                space.Property(e => e.Height).IsRequired();
            });
        });
    }
}
