using Microsoft.AspNetCore.Mvc;
using RetrievingDbRowAsJsonWithDapper.Contracts;

namespace RetrievingDbRowAsJsonWithDapper.Controllers;

[ApiController]
[Route("api/entities")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;
    private readonly IService _service;

    public Controller(ILogger<Controller> logger, IService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var vehicle = await _service.GetById(id);

            return vehicle == null ? NotFound() : Ok(vehicle);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}