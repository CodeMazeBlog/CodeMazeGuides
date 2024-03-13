namespace ReadingAppsettingsInConsoleApplication.Configurations.ConfigurationProviders.Abstracts;

public interface IConfigurationsProvider
{
    (string message, int number) GetApplicationSettings(ServiceProvider serviceProvider);
}