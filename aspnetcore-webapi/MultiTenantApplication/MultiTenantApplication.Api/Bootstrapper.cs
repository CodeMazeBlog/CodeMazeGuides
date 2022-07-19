namespace MultiTenantApplication.Api;

public static class Bootstrapper
{
    public static void Bootstrap(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtHelper.GetTokenParameters();
            });

        services.AddHttpContextAccessor();
        services.AddSingleton<ITenantRegistry, TenantRegistry>();
        services.AddScoped<ITenantResolver, TenantResolver>();
        services.AddTransient<IGoodsRepository, GoodsRepository>();
        services.AddDbContext<InventoryDbContext>(o =>
        {
            o.UseSqlServer(options => options.MigrationsAssembly(typeof(InventoryDbContext).Assembly.FullName));
        });

        EnsureLatestDatabase(services);
    }

    static void EnsureLatestDatabase(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();

        var connections = provider.GetRequiredService<ITenantRegistry>()
            .Tenants
            .Select(e => e.ConnectionString)
            .Distinct();

        foreach (var connection in connections)
        {
            var db = new MigrationDbContextFactory().CreateDbContext(Array.Empty<string>());
            db.Database.SetConnectionString(connection);

            if (db.Database.GetPendingMigrations().Any())
                db.Database.Migrate();            
        }
    }
}