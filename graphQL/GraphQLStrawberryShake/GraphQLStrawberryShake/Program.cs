var builder = WebApplication.CreateBuilder(args);
var graphQLUrl = builder.Configuration["ShippingContainerUrl"]!;

builder.Services.AddControllers();
builder.Services
    .AddShippingContainerClient()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(graphQLUrl);
    });

var app = builder.Build();

app.MapControllers();

app.Run();
