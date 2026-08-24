using AuthorsService.Data;
using AuthorsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController(Repository repository) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<Author>> Get() => repository.GetAuthorsAsync();
}
