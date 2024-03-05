using ReadingAppsettingsInConsoleApplication.Configurations.Models;

namespace ReadingAppsettingsInConsoleApplication.Configurations.ConfigurationProviders;

public class StrongTypeConfigurationRetrieval : IConfigurationsProvider
{
    public (string message, int number) GetApplicationSettings(ServiceProvider serviceProvider)
    {
        var configurationInstance = serviceProvider.GetService<IConfiguration>();
        var settings = configurationInstance?.GetSection("ApplicationSettings").Get<ApplicationSettings>();

        string message = settings?.Message ?? string.Empty;
        int number = settings?.Number ?? 0;

        return (message, number);
    }
}