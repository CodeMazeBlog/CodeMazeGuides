using GenerateSqlQueryInEFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiContext>(opts => opts
                .UseSqlServer(builder.Configuration["ConnectionString:CarsDB"]));
builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/cars", (ICarRepository carRepository) =>
{
    return carRepository.GetCars();
});

app.Run();