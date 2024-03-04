using Microsoft.Extensions.Configuration;
using IConfigurationProvider = ReadingAppsettingsInConsoleApplication.Configurations.Helpers.Abstracts.IConfigurationProvider;

namespace ReadingAppsettingsInConsoleApplication.Configurations.Helpers;

public class SimpleKeyValueRetrievalConfiguration(IConfiguration configuration) : IConfigurationProvider
{
    public (string message, int number) GetApplicationSettings()
    {
        string message = configuration["ApplicationSettings:Message"];
        string numberStr = configuration["ApplicationSettings:Number"];
        int number = Convert.ToInt32(numberStr);

        return (message, number);
    }
}