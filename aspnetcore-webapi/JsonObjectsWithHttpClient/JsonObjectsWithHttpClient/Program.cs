using JsonObjectsWithHttpClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/postAsStringContent", async (IPetService petService)
    => await petService.PostAsStringContent());

app.MapPost("/postAsJson", async (IPetService petService)
    => await petService.PostAsJson());

app.Run();