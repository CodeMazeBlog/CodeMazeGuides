namespace MultiTenantApplication.Infrastructure.Data;

#nullable disable

public class InventoryDbContext : DbContext
{
    private readonly Tenant _tenant;

    public InventoryDbContext(DbContextOptions options, ITenantResolver tenantResolver)
        : base(options)
    {
        _tenant = tenantResolver.GetCurrentTenant();
        Database.SetConnectionString(_tenant.ConnectionString);
    }

    public DbSet<Goods> Goods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Goods>().HasKey(e => e.Id);
        modelBuilder.Entity<Goods>().Property(e => e.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Goods>().Property(e => e.TenantId).IsRequired().ValueGeneratedOnAdd();

        modelBuilder.Entity<Goods>().HasQueryFilter(e => e.TenantId == _tenant.Name);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach(var entry in ChangeTracker.Entries<IHaveTenant>().Where(e => e.State == EntityState.Added))
        {
            entry.Entity.TenantId = _tenant.Name;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}