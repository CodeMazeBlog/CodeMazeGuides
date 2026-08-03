using RateLimitingDemo.Common.Repositories;
using RateLimitingDemo.UsingCustomMiddleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductCatalogRepository, ProductCatalogRepository>();
builder.Services.AddDistributedMemoryCache();
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

app.UseRateLimiting();

app.MapControllers();

app.Run();
