using JsonObjectsWithHttpClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IPetService, PetService>(client =>
{
    client.BaseAddress = new Uri("https://petstore.swagger.io/v2/");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/postAsStringContent", async (IPetService petService)
    => await petService.PostAsStringContentAsync());

app.MapPost("/postAsJson", async (IPetService petService)
    => await petService.PostAsJsonAsync());

app.Run();