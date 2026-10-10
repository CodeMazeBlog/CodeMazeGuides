using JsonObjectsWithHttpClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHttpClient<IPetService, PetService>(client =>
{
    client.BaseAddress = new Uri("https://petstore.swagger.io/v2/");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/postAsStringContent", async (IPetService petService)
    => await petService.PostAsStringContentAsync());

app.MapPost("/postAsJson", async (IPetService petService)
    => await petService.PostWithPostAsJsonAsync());

app.MapPost("/postAsJsonContent", async (IPetService petService)
    => await petService.PostAsJsonContentAsync());

app.MapPost("/postAsSourceGeneratedJson", async (IPetService petService)
    => await petService.PostAsSourceGeneratedJsonAsync());

app.Run();