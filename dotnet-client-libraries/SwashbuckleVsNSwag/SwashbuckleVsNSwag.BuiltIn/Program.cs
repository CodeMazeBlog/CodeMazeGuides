using SwashbuckleVsNSwag.Repositories.CustomerRepository;
using SwashbuckleVsNSwag.Repositories.OrderRepository;
using SwashbuckleVsNSwag.Repositories.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Built-in OpenAPI document generation (Microsoft.AspNetCore.OpenApi)
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Serve the document as JSON and as YAML
    app.MapOpenApi();
    app.MapOpenApi("/openapi/{documentName}.yaml");

    //Swagger UI from Swashbuckle.AspNetCore.SwaggerUi, pointed at the built-in document
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API using built-in OpenAPI");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
