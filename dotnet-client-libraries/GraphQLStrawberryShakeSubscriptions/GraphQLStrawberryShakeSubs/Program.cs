var builder = WebApplication.CreateBuilder(args);
var graphQLUrl = builder.Configuration["ShippingContainerUrl"]!;
var wsGraphQLUrl = builder.Configuration["WebSocketShippingContainerUrl"]!;

builder.Services.AddControllers();
builder.Services
    .AddShippingContainerSubClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(graphQLUrl))
    .ConfigureWebSocketClient(client => client.Uri = new Uri(wsGraphQLUrl));

var app = builder.Build();

app.MapControllers();

app.Run();
