using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Grpc;
using CodeMazeShop.Services.ShoppingCart.Facade;
using CodeMazeShop.Services.ShoppingCart.Messaging;
using CodeMazeShop.Services.ShoppingCart.Repositories;
using Polly;
using Polly.Extensions.Http;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDiscountFacade, DiscountFacade>();
builder.Services.AddScoped<IProductCatalogFacade, ProductCatalogFacade>();   
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Redis Configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration["CacheSettings:ConnectionString"];
});

builder.Services.AddHttpClient<IProductCatalogFacade, ProductCatalogFacade>(c
    => c.BaseAddress = new Uri(configuration["ServiceConfigs:ProductCatalog:Uri"]))
        .AddPolicyHandler(GetRetryPolicy())
        .AddPolicyHandler(GetCircuitBreakerPolicy());

builder.Services.AddGrpcClient<Discounts.DiscountsClient>(o 
    => o.Address = new Uri(configuration["ServiceConfigs:Discount:Uri"]));

builder.Services.AddSingleton<IMessageProducer<CartCheckoutMessage>, CheckoutProducer>();
builder.Services.AddSingleton(sp =>
{
    var uri = new Uri(configuration["RabbitMq:Uri"]);
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    => HttpPolicyExtensions
         .HandleTransientHttpError()
         .WaitAndRetryAsync(5,
                            retryAttempt => TimeSpan.FromMilliseconds(Math.Pow(1.5, retryAttempt) * 1000),
                            (_, waitingTime) =>
                            {
                                Console.WriteLine("Retrying due to Polly retry policy");
                            });
IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    => HttpPolicyExtensions
         .HandleTransientHttpError()
         .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));
