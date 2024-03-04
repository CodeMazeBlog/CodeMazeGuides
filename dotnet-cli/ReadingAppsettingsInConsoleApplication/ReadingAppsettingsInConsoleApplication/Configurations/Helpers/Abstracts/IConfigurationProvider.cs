namespace ReadingAppsettingsInConsoleApplication.Configurations.Helpers.Abstracts;

public interface IConfigurationProvider
{
    (string message, int number) GetApplicationSettings();
}