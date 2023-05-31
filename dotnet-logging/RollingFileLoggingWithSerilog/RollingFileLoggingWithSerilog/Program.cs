
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .CreateLogger();

try
{
    Log.Information("Starting wb host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

