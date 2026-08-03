using DtoVsPoco.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

app.MapGet("/people-details", async (IPersonService personService)
    => await personService.GetPersonDetailsData());

app.Run();
