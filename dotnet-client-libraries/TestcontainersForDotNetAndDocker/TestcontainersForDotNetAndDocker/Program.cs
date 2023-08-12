
using TestcontainersForDotNetAndDocker.Repositories;
using TestcontainersForDotNetAndDocker.Services;

namespace TestcontainersForDotNetAndDocker;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<ICatRepository, CatRepository>();
        builder.Services.AddTransient<ICatService, CatService>();

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


        app.MapControllers();

        app.Run();
    }
}