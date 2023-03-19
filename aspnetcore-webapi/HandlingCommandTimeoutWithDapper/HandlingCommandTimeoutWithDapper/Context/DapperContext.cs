using Microsoft.Data.SqlClient;
using System.Data;

namespace HandlingCommandTimeoutWithDapper.Context
{
    public class DapperContext
    {
        private readonly string _connectionString;
        private readonly string _connectionStringWithTimeout;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
            _connectionStringWithTimeout = configuration.GetConnectionString("SqlConnectionWithTimeout");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public IDbConnection CreateConnectionWithTimeout()
            => new SqlConnection(_connectionStringWithTimeout);
    }
}
