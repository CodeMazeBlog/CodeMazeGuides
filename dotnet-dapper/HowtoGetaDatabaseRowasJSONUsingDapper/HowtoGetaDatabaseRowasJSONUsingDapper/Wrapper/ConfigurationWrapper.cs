namespace RetrievingDbRowAsJsonWithDapper.Wrapper;

public class ConfigurationWrapper : IConfigurationWrapper
{
    private readonly IConfiguration _configuration;

    public ConfigurationWrapper(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string? GetConnectionString(string name)
    {
        return _configuration.GetConnectionString(name);
    }
}
