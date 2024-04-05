using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandlingCircularRefsWhenWorkingWithJson.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetEmployees() => Ok(employeeService.GetEmployees());
}