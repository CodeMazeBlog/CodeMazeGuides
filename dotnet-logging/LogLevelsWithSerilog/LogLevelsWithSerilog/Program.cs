using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace LogLevelsWithSerilog;

public class Program
{
    public static void Main(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        Log.Information("Web Host started");
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSerilog(options =>
        {
            //we can configure serilog from configuration
            options.ReadFrom.Configuration(configuration);

            //or we can configure serilog via fluent api
            options.MinimumLevel.Information()
                   .WriteTo.Console(Serilog.Events.LogEventLevel.Warning, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                   .WriteTo.File("logs/myapplogs.txt",
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                   .WriteTo.MSSqlServer(
                        connectionString: "Server=localhost;Database=LogDb;Integrated Security=SSPI;",
                        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" },
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Fatal)
                   .Enrich.WithProperty("AppName", "Serilog Demo")
                   .Enrich.WithProperty("Environment", "Development")
                   .Enrich.WithProperty("Author", "codemaze");
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        app.UseSerilogRequestLogging();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseHttpsRedirection();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}