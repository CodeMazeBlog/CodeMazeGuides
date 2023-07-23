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

        [HttpGet("{id:guid}", Name = "timeoutInConnectionString")]
        public async Task<ActionResult<Company>> GetCompanyWithTimeoutInConnectionString(Guid id)
        {
            var company = await _companyRepo.GetCompanyWithTimeoutInConnectionString(id);

            return Ok(company);
        }

        [HttpGet("timeoutInQueryMultiple")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesWithTimeoutInInQueryMultiple()
        {
            var companies = await _companyRepo.GetCompaniesWithTimeoutInInQueryMultiple();

            return Ok(companies);
        }
    }
}