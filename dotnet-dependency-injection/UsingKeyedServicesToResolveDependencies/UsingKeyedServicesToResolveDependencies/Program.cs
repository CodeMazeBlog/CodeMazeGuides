using UsingKeyedServicesToResolveDependencies.Services.Abstractions;
using UsingKeyedServicesToResolveDependencies.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedScoped<IEventService, OnlineEventService>("online");
builder.Services.AddKeyedScoped<IEventService, InPersonEventService>("in-person");

builder.Services.AddScoped<OnlineEventProducer>();
builder.Services.AddScoped<InPersonEventProducer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/attendOnlineEvent", (OnlineEventProducer eventProducer) => 
    eventProducer.ProduceEvent());

app.MapGet("/attendInPersonEvent", (InPersonEventProducer eventProducer) =>
    eventProducer.ProduceEvent());

app.UseAuthorization();

app.MapControllers();

app.Run();