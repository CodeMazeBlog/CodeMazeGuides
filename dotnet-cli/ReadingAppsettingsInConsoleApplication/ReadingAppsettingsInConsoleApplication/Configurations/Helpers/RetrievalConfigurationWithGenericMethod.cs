using Microsoft.Extensions.Configuration;
using IConfigurationProvider = ReadingAppsettingsInConsoleApplication.Configurations.Helpers.Abstracts.IConfigurationProvider;

namespace ReadingAppsettingsInConsoleApplication.Configurations.Helpers;

public class RetrievalConfigurationWithGenericMethod(IConfiguration configuration) : IConfigurationProvider
{
    public (string message, int number) GetApplicationSettings()
    {
        string message2 = configuration.GetValue<string>("ApplicationSettings:Message");
        int number2 = configuration.GetValue<int>("ApplicationSettings:Number");

        return (message2, number2);
    }
}