using Microsoft.AspNetCore.Mvc;

namespace MultipleTasksDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Random _random = new Random();
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetEmployeeDetails(Guid id)
        {
            await Task.Delay(2000);
            return Ok(new
                      {
                          Id = id,
                          Name = $"Sam_{id}",
                          DateOfBirth = DateTime.Now.AddYears(-1*_random.Next(20,30)).Date,
                          Address = "Employee Dummy Address"
                      });
        }

        [HttpGet("salary/{id}")]
        public async Task<IActionResult> GetEmployeeSalary(Guid id)
        {
            await Task.Delay(1000);
            return Ok(new
                      {
                          Id = id,
                          SalaryInEuro = 25000
                      });
        }

        [HttpGet("rating/{id}")]
        public async Task<IActionResult> GetEmployeeRating(Guid id)
        {
            await Task.Delay(1000);

            return Ok(new
                      {
                          Id = id,
                          Rating = 4
                      });
        }
    }
}