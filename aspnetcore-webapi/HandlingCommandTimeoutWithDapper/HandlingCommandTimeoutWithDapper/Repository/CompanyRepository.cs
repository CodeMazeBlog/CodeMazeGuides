using Dapper;
using HandlingCommandTimeoutWithDapper.Context;
using HandlingCommandTimeoutWithDapper.Contracts;
using HandlingCommandTimeoutWithDapper.Model;

namespace HandlingCommandTimeoutWithDapper.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private const int TimeoutInSeconds = 5;
        private const string Delay = "'00:00:25'";

        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInConnectionStringAndDelayInQuery()
        {
            string query = @$"SELECT c.* FROM Company c WAITFOR DELAY {Delay};
                            SELECT e.* FROM Employee e WAITFOR DELAY {Delay}";

            using var connection = _context.CreateConnectionWithTimeout();
            var multipleResult = await connection.QueryMultipleAsync(query);
            var companies = await multipleResult.ReadAsync<Company>();
            var employees = await multipleResult.ReadAsync<Employee>();

            foreach (var company in companies)
            {
                company.Employees = employees.Where(e => e.CompanyId == company.Id).ToList();
            }

            return companies;
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInInQueryMultiple()
        {
            string query = @$"SELECT c.* FROM Company c WAITFOR DELAY {Delay};
                            SELECT e.* FROM Employee e WAITFOR DELAY {Delay}";

            using var connection = _context.CreateConnection();
            var multipleResult = await connection.QueryMultipleAsync(query, commandTimeout: TimeoutInSeconds);
            var companies = await multipleResult.ReadAsync<Company>();
            var employees = await multipleResult.ReadAsync<Employee>();

            foreach (var company in companies)
            {
                company.Employees = employees.Where(e => e.CompanyId == company.Id).ToList();
            }

            return companies;
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInQuery()
        {
            string query = @$"SELECT c.* FROM Company c WAITFOR DELAY {Delay}";

            using var connection = _context.CreateConnection();
            var companies = await connection.QueryAsync<Company>(query, commandTimeout: TimeoutInSeconds);

            return companies;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            string query = @$"SELECT c.* FROM Company c;
                            SELECT e.* FROM Employee e";

            using var connection = _context.CreateConnection();
            var multipleResult = await connection.QueryMultipleAsync(query);
            var companies = await multipleResult.ReadAsync<Company>();
            var employees = await multipleResult.ReadAsync<Employee>();

            foreach (var company in companies)
            {
                company.Employees = employees.Where(e => e.CompanyId == company.Id).ToList();
            }

            return companies;
        }
    }
}
