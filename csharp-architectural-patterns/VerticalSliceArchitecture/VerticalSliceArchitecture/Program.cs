using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.ServiceManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("GamingDB")
           .ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});

builder.Services.AddScoped<IServiceManager, ServiceManager>();

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
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    new Seed().SeedData(dataContext);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
