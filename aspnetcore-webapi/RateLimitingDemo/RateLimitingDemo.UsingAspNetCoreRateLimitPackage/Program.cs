using AspNetCoreRateLimit;
using AspNetCoreRateLimit.Redis;
using RateLimitingDemo.UsAspNetCoreRateLimitPackage.Model;
using RateLimitingDemo.UsAspNetCoreRateLimitPackage.Repositories;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IProductCatalogRepository, ProductCatalogRepository>();


//IP Addres Rate Limiting Configurations
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddInMemoryRateLimiting();

//Rate Limiting using distributed cache
//var redisOptions = ConfigurationOptions.Parse(builder.Configuration["ConnectionStrings:Redis"]);
//builder.Services.AddSingleton<IConnectionMultiplexer>(provider => ConnectionMultiplexer.Connect(redisOptions));
//builder.Services.AddRedisRateLimiting();

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

app.UseIpRateLimiting();

app.MapGet("/products",(IProductCatalogRepository repo) =>
{
    return Results.Ok(repo.GetAll());
}).Produces<IEnumerable<Product>>();

app.MapGet("/products/{id}", (IProductCatalogRepository repo, Guid id) =>
{
    var customer = repo.GetById(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
}).Produces<Product>();

app.MapPost("/products", (IProductCatalogRepository repo, Product product) =>
{
    repo.Create(product);
    return Results.Created($"/products/{product.Id}", product);
}).Produces(201, typeof(Product));

app.MapPut("/products/{id}", (IProductCatalogRepository repo, Guid id, Product updatedProduct) =>
{
    var customer = repo.GetById(id);
    if (customer is null)
    {
        return Results.NotFound();
    }

    repo.Update(updatedProduct);
    return Results.Ok(updatedProduct);
}).Produces<Product>();

app.MapDelete("/products/{id}", (IProductCatalogRepository repo, Guid id) =>
{
    repo.Delete(id);
    return Results.Ok();
});

app.Run();
public partial class Program { }
