using HandlingCommandTimeoutWithDapper.Model;

namespace HandlingCommandTimeoutWithDapper.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompaniesWithTimeoutInConnectionStringAndDelayInQuery();
        public Task<IEnumerable<Company>> GetCompaniesWithTimeoutInInQueryMultiple();
        public Task<IEnumerable<Company>> GetCompaniesWithTimeoutInQuery();
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
