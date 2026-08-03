using DistCacheExample.Models;
using DistCacheExample.Models.DataManager;
using DistCacheExample.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDataRepository<Employee>, EmployeeManager>();
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["ConnectionString:Redis"];
    options.InstanceName = "SampleInstance";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionString:EmployeeDB"]));

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

public partial class Program { }
