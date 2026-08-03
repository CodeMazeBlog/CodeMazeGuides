using GraphQLStrawberryShakeSubs.Server;
using GraphQLStrawberryShakeSubs.Server.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests.Server;

public class WebApiFixture : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(logging => logging.ClearProviders());
        builder.ConfigureTestServices(ConfigureDatabase);
    }

    private static void ConfigureDatabase(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(
            d => d.ServiceType ==
                typeof(DbContextOptions<ApplicationDbContext>));

        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDbForTesting");
        });

        var sp = services.BuildServiceProvider();

        using (var scope = sp.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            db.Database.EnsureCreated();

            Seed.Initialize(db);
        }
    }
}
