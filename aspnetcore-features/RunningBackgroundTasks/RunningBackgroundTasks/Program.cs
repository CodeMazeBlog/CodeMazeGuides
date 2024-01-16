using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.One_off;
using RunningBackgroundTasks.Services.Periodic;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton(TimeProvider.System);

        builder.Services.Configure<HostOptions>(options =>
        {
            options.ServicesStartConcurrently = true;
        });

        builder.Services.AddHostedService<InitializationHostedService>();
        //builder.Services.AddHostedService<InitializationBackgroundService>();
        //builder.Services.AddHostedService<InitializationHostedLifecycleService>();

        builder.Services.AddHostedService<PeriodicHostedService>();
        //builder.Services.AddHostedService<PeriodicBackgroundService>();
        //builder.Services.AddHostedService<PeriodicHostedLifecycleService>();

        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("ClientsDbConnectionString"),
                options => options.EnableRetryOnFailure()));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGet("/clients/active", (ApplicationDbContext context) =>
        {
            return context.Clients.Where(x => x.IsActive).AsNoTracking();
        })
        .WithName("GetActiveClients")
        .WithOpenApi();

        app.MapGet("/clients/archived", (ApplicationDbContext context) =>
        {
            return context.Clients.Where(x => !x.IsActive).AsNoTracking();
        })
        .WithName("GetArchivedClients")
        .WithOpenApi();

        app.Run();
    }
}
