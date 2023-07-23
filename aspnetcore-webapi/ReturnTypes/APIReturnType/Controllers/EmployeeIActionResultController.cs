using Microsoft.AspNetCore.Mvc;

namespace APIReturnType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeIActionResultController : ControllerBase
    {
        public IFakeRepository _repository;

        public EmployeeIActionResultController(IFakeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (!_repository.TryGetEmployee(id, out var employee))
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(Employee employee)
        {
            if (employee.Name.Length < 3 || employee.Name.Length > 30)
            {
                return BadRequest("Name should be between 3 and 30 characters.");
            }

            await _repository.AddEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }
    }
}
