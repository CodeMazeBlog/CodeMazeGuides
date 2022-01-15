using RateLimitingDemo.UsingCustomMiddleware.Decorators;
using RateLimitingDemo.UsingCustomMiddleware.Extensions;
using RateLimitingDemo.UsingCustomMiddleware.Model;
using RateLimitingDemo.UsingCustomMiddleware.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/products",
[LimitRequests(MaxRequests = 2, TimeWindow = 5)]
(IProductCatalogRepository repo) =>
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
}).Produces(201,typeof(Product));

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
