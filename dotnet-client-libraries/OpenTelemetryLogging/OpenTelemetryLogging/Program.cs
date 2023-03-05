using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryLogging;
using System.Diagnostics;

var activitySource = new ActivitySource("Logging.NET");

using var traceProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Logging.NET")
    .SetResourceBuilder(
        ResourceBuilder.CreateDefault()
            .AddService("Logging.NET"))
    .AddConsoleExporter()
    .AddJaegerExporter()
    .Build();

var serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Debug)
        .AddOpenTelemetry(options =>
            options.AddConsoleExporter()
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService("Logging.NET"))
                .AddProcessor(new ActivityEventLogProcessor())
                .IncludeScopes = true))
    .AddScoped<IUserSevice, UserService>()
    .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();

logger.LogDebug("This is a {severityLevel} message", LogLevel.Debug);

logger.LogInformation("{severityLevel} messages are used to provide contextual information", LogLevel.Information);

logger.LogError(new Exception("Application exception"), "These are usually accompanied by an exception");

using var activity = activitySource.StartActivity("Login");

var userService = serviceProvider.GetRequiredService<IUserSevice>();

userService.Login("codemaze", "Pa$$w0rd!!");