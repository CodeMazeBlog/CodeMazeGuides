using ProjectConfigurationDemo.Models.ConfigurationProviders;

namespace ProjectConfigurationDemo.Models;

public static class EntityConfigurationExtensions
{
    public static ConfigurationManager AddEntityConfiguration(this ConfigurationManager manager)
    {
        var connectionString = manager.GetConnectionString("sqlConnection");

        IConfigurationBuilder configBuilder = manager;
        configBuilder.Add(new EFConfigurationSource(connectionString));

        return manager;
    }
}
