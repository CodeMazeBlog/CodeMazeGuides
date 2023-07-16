using IdentityUserExtension.Data;
using IdentityUserExtension.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public static class TestServiceCollectionBuilder
{
    public static IServiceProvider CreateTestServiceProvider()
    {
        var services = new ServiceCollection();
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .AddEnvironmentVariables() 
            .AddUserSecrets<ApplicationDbContext>()
            .Build();
        
        var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

       return services.BuildServiceProvider();
    }
}