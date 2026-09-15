using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProjectConfigurationDemo.Models.ConfigurationProviders;

public class EFConfigurationProvider(string? connectionString) : ConfigurationProvider
{
    private readonly string? _connectionString = connectionString;

    public override void Load()
    {
        using var dbContext = new ConfigurationDbContext(_connectionString);

        dbContext.Database.EnsureCreated();

        Data = dbContext.ConfigurationEntities.Any()
            ? dbContext.ConfigurationEntities.ToDictionary(c => c.Key, c => c.Value, StringComparer.OrdinalIgnoreCase)
            : CreateAndSaveDefaultValues(dbContext);
    }

    private static Dictionary<string, string?> CreateAndSaveDefaultValues(ConfigurationDbContext dbContext)
    {
        var configValues = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
        {
            { "Pages:HomePage:WelcomeMessage", "Welcome to the ProjectConfigurationDemo Home Page" },
            { "Pages:HomePage:ShowWelcomeMessage", "true" },
            { "Pages:HomePage:Color", "black" },
            { "Pages:HomePage:UseRandomTitleColor", "true" }
        };

        dbContext.ConfigurationEntities.AddRange(
            [.. configValues.Select(kvp => new ConfigurationEntity { Key = kvp.Key, Value = kvp.Value })]);

        dbContext.SaveChanges();

        return configValues;
    }
}
