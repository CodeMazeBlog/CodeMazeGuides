using Microsoft.AspNetCore.Mvc;
using ModelStateValidation.ActionFilters;
using ModelStateValidation.Models;

namespace ModelStateValidation.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public IActionResult Post([FromBody] CreateBookInputModel createBookInputModel)
    {
        return Ok(createBookInputModel);
    }
}