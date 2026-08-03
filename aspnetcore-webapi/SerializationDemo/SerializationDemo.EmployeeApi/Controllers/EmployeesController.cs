using Microsoft.AspNetCore.Mvc;
using SerializationDemo.Common.Models;
using SerializationDemo.EmployeeApi.Repositories;

namespace SerializationDemo.EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeesController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        public IActionResult GetAllEmployees()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public IActionResult CreateEmployee(Employee employee)
        {
            _repo.Create(employee);
            return Created($"/employees/{employee.Id}", employee);
        }
    }
}
