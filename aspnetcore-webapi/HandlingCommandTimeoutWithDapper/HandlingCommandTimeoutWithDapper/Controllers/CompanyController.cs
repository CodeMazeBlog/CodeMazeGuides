using HandlingCommandTimeoutWithDapper.Contracts;
using HandlingCommandTimeoutWithDapper.Model;
using Microsoft.AspNetCore.Mvc;

namespace HandlingCommandTimeoutWithDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet("timeoutInConnectionString")]
        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInConnectionStringAndDelayInQuery()
        {
            var companies = await _companyRepo.GetCompaniesWithTimeoutInConnectionStringAndDelayInQuery();

            return companies;
        }

        [HttpGet("timeoutInQueryMultiple")]
        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInInQueryMultiple()
        {
            var companies = await _companyRepo.GetCompaniesWithTimeoutInInQueryMultiple();

            return companies;
        }

        [HttpGet("timeoutInQuery")]
        public async Task<IEnumerable<Company>> GetCompaniesWithTimeoutInQuery()
        {
            var companies = await _companyRepo.GetCompaniesWithTimeoutInQuery();

            return companies;
        }

        [HttpGet("timeoutCorrect")]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _companyRepo.GetCompanies();

            return companies;
        }
    }
}