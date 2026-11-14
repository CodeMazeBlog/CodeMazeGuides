using MessageTemplateForLoggingCA2254;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<Application>();

using var host = builder.Build();

var app = host.Services.GetRequiredService<Application>();

app.Run();
