using BooksService.Data;
using BooksService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksService.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(Repository repository) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Book> Get() => repository.GetBooks();
}
