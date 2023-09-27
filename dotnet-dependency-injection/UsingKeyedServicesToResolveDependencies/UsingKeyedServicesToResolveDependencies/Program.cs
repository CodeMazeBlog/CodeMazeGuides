using UsingKeyedServicesToResolveDependencies.Services;
using UsingKeyedServicesToResolveDependencies.Services.Abstractions;

namespace UsingKeyedServicesToResolveDependencies;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddKeyedScoped<IEventService, OnlineEventService>("online");
        builder.Services.AddKeyedScoped<IEventService, InPersonEventService>("in-person");

        builder.Services.AddScoped<OnlineEventOrchestrator>();
        builder.Services.AddScoped<InPersonEventOrchestrator>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}