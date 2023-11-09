using APIKeyAuthentication.CustomAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIKeyAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("all")]
        [Authorize(Policy = "ApiKeyPolicy")]
        public IActionResult GetEmployees()
        {
            return Ok();
        }
    }
}