using DifferenceBetweenRestfulAPIAndWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DifferenceBetweenRestfulAPIAndWebAPI.Controllers
{
    [Route("api/NonRestfulBooks")]
    [ApiController]
    public class NonRestfulBooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}