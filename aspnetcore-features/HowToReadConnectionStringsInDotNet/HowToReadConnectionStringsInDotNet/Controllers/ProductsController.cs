using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HowToReadConnectionStringsInDotNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IConfiguration _configuration; 
    
    public ProductsController(IConfiguration configuration) 
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetConnectionString()
    {
        var connString = _configuration.GetConnectionString("ProductsDb");
        
        // TODO: Use the connection string to access data.

        return Ok();
    }
}
