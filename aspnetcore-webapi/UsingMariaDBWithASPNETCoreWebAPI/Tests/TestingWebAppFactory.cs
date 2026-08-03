using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UsingMariaDBWithASPNETCoreWebAPI.Models;

namespace Tests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryStudentTest");
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }
    }
}