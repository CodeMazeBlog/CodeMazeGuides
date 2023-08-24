namespace MultiTenantApplication.Api;

public static class DatabaseHelper
{
    public static void EnsureLatestDatabase(IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();

        var connections = provider.GetRequiredService<ITenantRegistry>()
            .GetTenants()
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