using CustomPropertiesWithSerilog;
using Serilog;

Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} " +
                                             "[{Level:u3}] [{UserId}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

var exampleWithFromContextEnricher = new CustomPropertiesFromContextEnricher(Log.Logger);

string userId = "newUser";
exampleWithFromContextEnricher.EnrichFromContextPushProperty(userId);
exampleWithFromContextEnricher.EnrichFromContextPushPropertyScoped(userId);
exampleWithFromContextEnricher.EnrichFromContextForContext(userId);


Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("Version", "1.0.0")
    .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} " +
                                     "[{Level:u3}] [{Version}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

var examplesWithPropertyEnricher = new CustomPropertiesWithPropertyEnricher(Log.Logger);

examplesWithPropertyEnricher.LogUsingPropertyEnrichedLogger();

Log.CloseAndFlush();