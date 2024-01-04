using MessageTemplateForLoggingCA2254;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddEnvironmentVariables()
    .Build();

var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration(config =>
    {
        config.AddConfiguration(configuration);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<Application>();
    })
    .Build();

var app = host.Services.GetRequiredService<Application>();

app.Run();
