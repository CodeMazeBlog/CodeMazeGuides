using Microsoft.AspNetCore.Mvc;

namespace APIReturnType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IFakeRepository _repository;

        public EmployeeController(IFakeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Employee> Get() =>
            _repository.GetEmployees();

        [HttpGet("active")]
        public IEnumerable<Employee> GetActive()
        {
            foreach (var employee in _repository.GetActiveEmployees())
            {
                yield return employee;
            }
        }

        [HttpGet("activeasync")]
        public async IAsyncEnumerable<Employee> GetActiveAsync()
        {
            await foreach (var employee in _repository.GetActiveEmployeesAsync())
            {
                yield return employee;
            }
        }
    }
}
