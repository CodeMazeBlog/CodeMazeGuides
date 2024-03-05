namespace ReadingAppsettingsInConsoleApplication.Configurations.ConfigurationProviders;

public class SimpleKeyValueRetrievalConfiguration : IConfigurationsProvider
{
    public (string message, int number) GetApplicationSettings(ServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetService<IConfiguration>();
        string message = configuration["ApplicationSettings:Message"];
        string numberStr = configuration["ApplicationSettings:Number"];
        int number = Convert.ToInt32(numberStr);

        return (message, number);
    }
}