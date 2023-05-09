using SwashbuckleVsNSwag.Repositories.CustomerRepository;
using SwashbuckleVsNSwag.Repositories.OrderRepository;
using SwashbuckleVsNSwag.Repositories.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//NSwag configuration
builder.Services.AddOpenApiDocument(c => 
{ 
    c.DocumentName = "v1"; 
    c.Title = "API using NSwag"; 
    c.Version = "v1"; 
});

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Enable Swagger
    app.UseOpenApi(p => p.Path = "/swagger/v1/swagger.yaml"); 
    app.UseReDoc(p => p.DocumentPath = "/swagger/v1/swagger.yaml");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
