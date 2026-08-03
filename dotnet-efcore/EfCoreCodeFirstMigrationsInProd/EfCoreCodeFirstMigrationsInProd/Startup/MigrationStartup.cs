using EfCoreCodeFirstMigrationsInProd.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirstMigrationsInProd.Startup;

public class MigrationStartup : IStartup
{
    public async Task StartAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<WeatherDbContext>((sp, o) =>
        {
            o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        });

        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<WeatherDbContext>().Database.MigrateAsync();
    }
}