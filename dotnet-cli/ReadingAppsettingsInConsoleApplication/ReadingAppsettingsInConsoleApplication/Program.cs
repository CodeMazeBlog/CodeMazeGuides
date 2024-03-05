using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

var tmp1 = new SimpleKeyValueRetrievalConfiguration();
var tmp2 = new RetrievalConfigurationWithGenericMethod();
var tmp3 = new StrongTypeConfigurationRetrieval();

