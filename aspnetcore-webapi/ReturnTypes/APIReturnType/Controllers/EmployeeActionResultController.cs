using Microsoft.AspNetCore.Mvc;

namespace APIReturnType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeActionResultController : ControllerBase
    {
        public IFakeRepository _repository;

        public EmployeeActionResultController(IFakeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee?> GetById(int id)
        {
            if (!_repository.TryGetEmployee(id, out var employee))
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> CreateAsync(Employee employee)
        {
            int? employeeNameLength = employee?.Name?.Length;
            if (employeeNameLength < 3 || employeeNameLength > 30)
            {
                return BadRequest("Name should be between 3 and 30 characters.");
            }

            await _repository.AddEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetById), new { id = employee?.Id }, employee);
        }
    }
}
