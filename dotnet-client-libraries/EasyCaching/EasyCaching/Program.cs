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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

public partial class Program { }
