using FluentMigrator.Runner;
using HandlingCommandTimeoutWithDapper.Migrations;

namespace HandlingCommandTimeoutWithDapper;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        try
        {
            databaseService.CreateDatabase("DapperASPNetCore");

            migrationService.ListMigrations();
            migrationService.MigrateDown(202106280001);

        }
        catch
        {
            //log errors or ...
            throw;
        }

        return host;
    }
}