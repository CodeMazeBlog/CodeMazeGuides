var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEasyCaching(options =>
{
    options.UseInMemory(configuration, "InMemoryCache", "EasyCaching:InMemoryCache");
    options.UseSQLite(config =>
    {
        config.DBConfig = new EasyCaching.SQLite.SQLiteDBOptions { FileName = "cache.db" };
    }, "SQLiteCache");
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
