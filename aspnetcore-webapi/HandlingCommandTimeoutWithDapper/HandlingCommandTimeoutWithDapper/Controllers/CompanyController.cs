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
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesWithTimeoutInConnectionStringAndDelayInQuery()
        {
            try
            {
                var companies = await _companyRepo.GetCompaniesWithTimeoutInConnectionStringAndDelayInQuery();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, new ProblemDetails { Status = StatusCodes.Status504GatewayTimeout });
            }

        }

        [HttpGet("timeoutInQueryMultiple")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesWithTimeoutInInQueryMultiple()
        {
            try
            {
                var companies = await _companyRepo.GetCompaniesWithTimeoutInInQueryMultiple();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, new ProblemDetails { Status = StatusCodes.Status504GatewayTimeout });
            }

        }

        [HttpGet("timeoutInQuery")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesWithTimeoutInQuery()
        {
            try
            {
                var companies = await _companyRepo.GetCompaniesWithTimeoutInQuery();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, new ProblemDetails { Status = StatusCodes.Status504GatewayTimeout });
            }
        }

        [HttpGet("timeoutCorrect")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _companyRepo.GetCompanies();

            return Ok(companies);
        }
    }
}