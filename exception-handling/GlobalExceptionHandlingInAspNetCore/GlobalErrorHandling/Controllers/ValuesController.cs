using GlobalErrorHandling.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController(ILogger<ValuesController> logger) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        logger.LogInformation("Fetching all the Students from the storage");

        var students = DataManager.GetAllStudents(); //simulation for the data base access

        throw new AccessViolationException("Violation Exception while accessing the resource.");

        logger.LogInformation("Returning {Count} students.", students.Count);

        return Ok(students);
    }
}
