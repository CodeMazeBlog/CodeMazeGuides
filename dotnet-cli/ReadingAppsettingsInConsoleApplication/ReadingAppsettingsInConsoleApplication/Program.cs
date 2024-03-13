using ReadingAppsettingsInConsoleApplication.Configurations.ConfigurationProviders;

Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "development");
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(
        string.IsNullOrWhiteSpace(environment) ? 
            "appsettings.json" : 
            $"appsettings.{environment}.json")
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration)
    .BuildServiceProvider();

var simpleKeyValueRetrievalConfiguration = new SimpleKeyValueRetrievalConfiguration();
var retrievalConfigurationWithGenericMethod = new RetrievalConfigurationWithGenericMethod();
var strongTypeConfigurationRetrieval = new StrongTypeConfigurationRetrieval();

var(message1, number1) = simpleKeyValueRetrievalConfiguration.GetApplicationSettings(serviceProvider);
var(message2, number2) = retrievalConfigurationWithGenericMethod.GetApplicationSettings(serviceProvider);
var(message3, number3) = strongTypeConfigurationRetrieval.GetApplicationSettings(serviceProvider);

Console.WriteLine($"Message for {nameof(SimpleKeyValueRetrievalConfiguration)} is {message1}");
Console.WriteLine($"Message for {nameof(RetrievalConfigurationWithGenericMethod)} is {message2}");
Console.WriteLine($"Message for {nameof(StrongTypeConfigurationRetrieval)} is {message3}");

