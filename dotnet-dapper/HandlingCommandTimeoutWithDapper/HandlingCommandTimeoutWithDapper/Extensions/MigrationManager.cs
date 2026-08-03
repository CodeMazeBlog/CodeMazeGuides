using FluentMigrator.Runner;
using HandlingCommandTimeoutWithDapper.Migrations;

namespace HandlingCommandTimeoutWithDapper.Extensions;

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

            migrationService.MigrateUp();
        }
        catch
        {
            //log errors or ...
            throw;
        }

        return host;
    }
}