using Microsoft.Extensions.Configuration;

namespace DynamicDbContextSwitching;

public class DataSourceProvider : IDataSourceProvider
{
    private readonly IConfiguration _configuration;

    public DataSource CurrentDataSource { get; set; }
    
    public DataSourceProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string? GetConnectionString()
    {
        return CurrentDataSource switch
        {
            DataSource.Primary => _configuration.GetConnectionString("Primary"),
            DataSource.Secondary => _configuration.GetConnectionString("Secondary"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public interface IDataSourceProvider
{
    DataSource CurrentDataSource { set; }
    string? GetConnectionString();
}