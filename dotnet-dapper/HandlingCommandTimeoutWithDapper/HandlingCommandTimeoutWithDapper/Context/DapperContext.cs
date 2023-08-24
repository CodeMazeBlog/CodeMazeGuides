using Microsoft.Data.SqlClient;
using System.Data;

namespace HandlingCommandTimeoutWithDapper.Context
{
    public class DapperContext
    {
        private readonly string _connectionString;
        private readonly string _connectionStringWithTimeout;
        private readonly string _connectionStringMaster;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
            _connectionStringWithTimeout = configuration.GetConnectionString("SqlConnectionWithTimeout");
            _connectionStringMaster = configuration.GetConnectionString("SqlMasterConnection");
        }

        public IDbConnection CreateConnectionWithoutTimeout()
            => new SqlConnection(_connectionString);

        public IDbConnection CreateConnectionWithTimeout()
            => new SqlConnection(_connectionStringWithTimeout);

        public IDbConnection CreateMasterConnection()
            => new SqlConnection(_connectionStringMaster);
    }
}
