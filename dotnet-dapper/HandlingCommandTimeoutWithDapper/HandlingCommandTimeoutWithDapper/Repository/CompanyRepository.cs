using Dapper;
using HandlingCommandTimeoutWithDapper.Context;
using HandlingCommandTimeoutWithDapper.Contracts;
using HandlingCommandTimeoutWithDapper.Model;

namespace HandlingCommandTimeoutWithDapper.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private const int TimeoutInSeconds = 5;

        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context) => _context = context;

        public async Task<Company> GetCompanyWithTimeoutInConnectionString(Guid id)
        {
            string query = @"SELECT * FROM Company WHERE Id = @Id";

            using var connection = _context.CreateConnectionWithTimeout();
            var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });

            return company;
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInInQueryMultiple()
        {
            string query = @"SELECT * FROM Company";

            using var connection = _context.CreateConnectionWithoutTimeout();
            var multipleResult = await connection.QueryMultipleAsync(query, commandTimeout: TimeoutInSeconds);
            var companies = await multipleResult.ReadAsync<Company>();

            return companies;
        }
    }
}
