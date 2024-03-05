namespace ReadingAppsettingsInConsoleApplication.Configurations.ConfigurationProviders;

public class RetrievalConfigurationWithGenericMethod : IConfigurationsProvider
{
    public (string message, int number) GetApplicationSettings(ServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetService<IConfiguration>();
        string message2 = configuration.GetValue<string>("ApplicationSettings:Message");
        int number2 = configuration.GetValue<int>("ApplicationSettings:Number");

        return (message2, number2);
    }
}