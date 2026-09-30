using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIReturnType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeHttpResultsController : ControllerBase
    {
        public IFakeRepository _repository;

        public EmployeeHttpResultsController(IFakeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public Results<NotFound, Ok<Employee>> GetById(int id)
        {
            if (!_repository.TryGetEmployee(id, out var employee))
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(employee);
        }

        [HttpPost]
        public async Task<Results<BadRequest<string>, Created<Employee>>> CreateAsync(Employee employee)
        {
            if (employee.Name is not { Length: >= 3 and <= 30 })
            {
                return TypedResults.BadRequest("Name should be between 3 and 30 characters.");
            }

            await _repository.AddEmployeeAsync(employee);

            return TypedResults.Created($"/api/employeehttpresults/{employee.Id}", employee);
        }
    }
}
