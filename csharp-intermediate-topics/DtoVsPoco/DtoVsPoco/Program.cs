using DtoVsPoco.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

app.MapGet("/people-info", async (IPersonService personService)
    => await personService.GetPersonInfoData());

app.MapGet("/people-details", async (IPersonService personService)
    => await personService.GetPersonDetailsData());

app.Run();
