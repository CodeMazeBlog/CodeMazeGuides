using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddEnvironmentVariables()
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddConfiguration(configuration);
    })
    .Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

const string userName = "John Doe";
var loginTime = DateTime.Now;

logger.LogInformation($"User {userName} logged in at {loginTime}");
