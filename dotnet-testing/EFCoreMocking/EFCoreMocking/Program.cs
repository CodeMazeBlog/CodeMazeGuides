using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFCoreMocking.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDataContext") ?? throw new InvalidOperationException("Connection string 'EmployeeDataContext' not found.")));

// Add services to the container.

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EmployeeDBContext>();
    context.Database.EnsureCreated();    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
