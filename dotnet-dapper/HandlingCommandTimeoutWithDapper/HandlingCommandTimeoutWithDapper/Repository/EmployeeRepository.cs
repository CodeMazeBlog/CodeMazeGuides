using Dapper;
using HandlingCommandTimeoutWithDapper.Context;
using HandlingCommandTimeoutWithDapper.Contracts;
using HandlingCommandTimeoutWithDapper.Model;

namespace HandlingCommandTimeoutWithDapper.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const int TimeoutInSeconds = 50;

        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            SqlMapper.Settings.CommandTimeout = TimeoutInSeconds;
            string query = @"SELECT * FROM Employee";

            using var connection = _context.CreateConnectionWithoutTimeout();
            var employees = await connection.QueryAsync<Employee>(query);

            return employees;
        }
    }
}
