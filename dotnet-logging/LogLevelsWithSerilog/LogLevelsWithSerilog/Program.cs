using Serilog;
using Serilog.Core;
using Serilog.Events;

var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.Development.json")
           .Build();

Log.Information("Web Host started");
var builder = WebApplication.CreateBuilder(args);

// Wrapping the minimum level in a LoggingLevelSwitch lets us change it at
// runtime -- e.g. from an admin endpoint -- with no redeploy and no restart.
var levelSwitch = new LoggingLevelSwitch(LogEventLevel.Information);

builder.Services.AddSerilog(options =>
{
    //we can configure serilog from configuration
    options.ReadFrom.Configuration(configuration);

    //or we can configure serilog via fluent api
    options.MinimumLevel.ControlledBy(levelSwitch)
           .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
           .MinimumLevel.Override("System", LogEventLevel.Warning)
           .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
           .WriteTo.File("logs/log-.txt",
                rollOnFileSizeLimit: true,
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: 1000000,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                restrictedToMinimumLevel: LogEventLevel.Warning);
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

// e.g. POST /admin/log-level/Debug -- flips the minimum level on every sink
// immediately, with no restart.
app.MapPost("/admin/log-level/{level}", (LogEventLevel level) =>
{
    levelSwitch.MinimumLevel = level;
    return Results.Ok($"Minimum log level set to {level}.");
});

app.Run();