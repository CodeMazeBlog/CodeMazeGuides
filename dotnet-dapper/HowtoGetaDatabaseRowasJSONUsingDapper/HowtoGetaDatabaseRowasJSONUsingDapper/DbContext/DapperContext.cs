using Microsoft.Data.SqlClient;
using RetrievingDbRowAsJsonWithDapper.Wrapper;
using System.Data;

namespace RetrievingDbRowAsJsonWithDapper.DbContext;

public class DapperContext
{
    private readonly IConfigurationWrapper _configuration;
    private readonly string? _connectionString;

    public DapperContext(IConfigurationWrapper configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
