using HandlingCommandTimeoutWithDapper.Model;

namespace HandlingCommandTimeoutWithDapper.Contracts
{
    public interface ICompanyRepository
    {
        public Task<Company> GetCompanyWithTimeoutInConnectionString(Guid id);
        public Task<IEnumerable<Company>> GetCompaniesWithTimeoutInInQueryMultiple();
    }
}
