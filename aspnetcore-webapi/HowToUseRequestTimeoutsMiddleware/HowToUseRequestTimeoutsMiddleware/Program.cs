using HowToUseRequestTimeoutsMiddleware.Services;
using Microsoft.AspNetCore.Http.Timeouts;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRequestTimeouts(options =>
{
    options.DefaultPolicy = new RequestTimeoutPolicy
    {
        Timeout = TimeSpan.FromMilliseconds(1500),
        TimeoutStatusCode = (int)HttpStatusCode.InternalServerError
    };
    options.AddPolicy("OneSecondTimeout", TimeSpan.FromMilliseconds(1000));
});

builder.Services.AddTransient<ICharacterService, StarWarsCharacterService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseRequestTimeouts();

app.MapGet("/GetCharacter",
    [RequestTimeout("OneSecondTimeout")] async (HttpContext context, ICharacterService characterService) =>
{
    return await characterService.GetCharacterAsync(context.RequestAborted);
});

app.Run();
