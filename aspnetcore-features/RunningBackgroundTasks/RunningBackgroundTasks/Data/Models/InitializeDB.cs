using Microsoft.EntityFrameworkCore;

namespace RunningBackgroundTasks.Data.Models;

public static class InitializeDB
{
    public static void PrePopulate(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        context.Database.Migrate();

        SeedDatabase(context);
    }

    public static void SeedDatabase(ApplicationDbContext context)
    {
        context.Clients.AddRange(
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "HP",
            },
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "Lenovo",
            },
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "Dell",
            },
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
            },
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "Acer",
            },
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "Asus",
            },
            new Client
            {
                Id = Guid.NewGuid(),
                Name = "Razer",
            }
        );
    }
}
