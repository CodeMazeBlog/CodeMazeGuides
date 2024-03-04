using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingAppsettingsInConsoleApplication.Configurations.Models;
using IConfigurationProvider = ReadingAppsettingsInConsoleApplication.Configurations.Helpers.Abstracts.IConfigurationProvider;

namespace ReadingAppsettingsInConsoleApplication.Configurations.Helpers;

public class StrongTypeConfigurationRetrieval(ServiceProvider serviceProvider) : IConfigurationProvider
{
    public (string message, int number) GetApplicationSettings()
    {
        var configurationInstance = serviceProvider.GetService<IConfiguration>();
        var settings = configurationInstance?.GetSection("ApplicationSettings").Get<ApplicationSettings>();

        string message3 = settings?.Message ?? string.Empty;
        int number3 = settings?.Number ?? 0;

        return (message3, number3);
    }
}