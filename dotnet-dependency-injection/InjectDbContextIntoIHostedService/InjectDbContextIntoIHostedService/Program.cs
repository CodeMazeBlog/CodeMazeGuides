using InjectDbContextIntoIHostedService.Data;
using InjectDbContextIntoIHostedService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<CatsSeedingService>();

builder.Services.AddDbContextFactory<CatsDbContext>(options
    => options.UseInMemoryDatabase("Cats"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cats", async (CatsDbContext context) =>
{
    return await context.Cats.AsNoTracking().ToListAsync();
})
.WithName("GetCats")
.WithOpenApi();

app.Run();

public partial class Program { }