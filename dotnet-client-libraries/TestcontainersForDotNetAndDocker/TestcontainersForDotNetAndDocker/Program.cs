using Microsoft.EntityFrameworkCore;
using TestcontainersForDotNetAndDocker.Database;
using TestcontainersForDotNetAndDocker.Repositories;
using TestcontainersForDotNetAndDocker.Services;

namespace TestcontainersForDotNetAndDocker;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnectionString")));
            
        builder.Services.AddScoped<ICatRepository, CatRepository>();
        builder.Services.AddScoped<ICatService, CatService>();
        builder.Services.AddScoped<DatabaseInitializer, DatabaseInitializer>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<DatabaseInitializer>();
        await context.InitializeAsync();

        app.MapControllers();

        app.Run();
    }
}