using ChangeServiceLifetimeOfAlreadyRegisteredService;
using ChangeServiceLifetimeOfAlreadyRegisteredService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService, DefaultService>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.ReplaceWithSingleton<IService, LocalDevelopmentService>();
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/use-service", (IService service) => Results.Ok())
    .WithName("UseService")
    .WithOpenApi();

app.Run();