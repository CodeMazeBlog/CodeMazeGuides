using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandlingCircularRefsWhenWorkingWithJson.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetEmployees() => Ok(_employeeService.GetEmployees());
}