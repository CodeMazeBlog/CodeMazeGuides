using Microsoft.EntityFrameworkCore.Design;

namespace MultiTenantApplication.Infrastructure.Data;

public class MigrationDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
    public InventoryDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<InventoryDbContext>();
        builder.UseSqlServer();

        return new InventoryDbContext(builder.Options, new MigrationTenantResolver());
    }

    private class MigrationTenantResolver : ITenantResolver
    {
        private readonly Tenant _tenant;

        public MigrationTenantResolver()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            var defaultConnection = configuration.GetSection("TenantOptions")
                .GetValue<string>("DefaultConnection");

            _tenant = new Tenant { Name = "Migration", ConnectionString = defaultConnection };
        }

        public Tenant GetCurrentTenant() => _tenant;        
    }
}