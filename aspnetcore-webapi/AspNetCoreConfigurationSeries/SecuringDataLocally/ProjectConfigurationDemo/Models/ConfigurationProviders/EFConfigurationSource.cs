using Microsoft.Extensions.Configuration;

namespace ProjectConfigurationDemo.Models.ConfigurationProviders;

public class EFConfigurationSource(string? connectionString) : IConfigurationSource
{
    private readonly string? _connectionString = connectionString;

    public IConfigurationProvider Build(IConfigurationBuilder builder)
        => new EFConfigurationProvider(_connectionString);
}
