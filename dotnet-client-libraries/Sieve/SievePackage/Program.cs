using Sieve.Models;
using Sieve.Services;
using SievePackage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));

builder.Services.AddScoped<ISieveProcessor, CustomSieveProcessor>();
builder.Services.AddScoped<IShoeRetrievalService, ShoeRetrievalService>();

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