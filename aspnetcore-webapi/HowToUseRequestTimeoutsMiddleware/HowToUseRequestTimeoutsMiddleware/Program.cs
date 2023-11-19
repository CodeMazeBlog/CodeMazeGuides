using HowToUseRequestTimeoutsMiddleware.Services;
using Microsoft.AspNetCore.Http.Timeouts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRequestTimeouts(options =>
{
    options.AddPolicy("OneSecondTimeout", TimeSpan.FromMilliseconds(1000));
});

builder.Services.AddTransient<IStarWarsService, StarWarsService>();

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
    async (HttpContext context, IStarWarsService starWarsService) =>
{
    return await starWarsService.GetCharacterAsync(context.RequestAborted);
})
.DisableRequestTimeout();

app.Run();
