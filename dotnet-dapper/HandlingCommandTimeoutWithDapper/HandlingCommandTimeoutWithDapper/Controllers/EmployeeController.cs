using HandlingCommandTimeoutWithDapper.Contracts;
using HandlingCommandTimeoutWithDapper.Model;
using Microsoft.AspNetCore.Mvc;

namespace HandlingCommandTimeoutWithDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet("globalTimeoutCorrect")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetCompanies()
        {
            var companies = await _employeeRepo.GetEmployees();

            return Ok(companies);
        }
    }
}