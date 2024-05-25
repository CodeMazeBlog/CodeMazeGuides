using BackgroundServiceExecuteAsyncAndStartAsync;
using BackgroundServiceExecuteAsyncAndStartAsync.Data;
using BackgroundServiceExecuteAsyncAndStartAsync.Repositories;
using BackgroundServiceExecuteAsyncAndStartAsync.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StockPricesDbContext>(options =>
    options.UseInMemoryDatabase("StockPrices"));

builder.Services.AddTransient<IStockPriceService, StockPriceService>();
builder.Services.AddScoped<IStockPriceRepository, StockPriceRepository>();
builder.Services.AddHostedService<StockPricesBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();