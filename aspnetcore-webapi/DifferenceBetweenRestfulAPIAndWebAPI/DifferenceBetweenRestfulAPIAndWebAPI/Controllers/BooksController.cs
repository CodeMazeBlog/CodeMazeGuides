using DifferenceBetweenRestfulAPIAndWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DifferenceBetweenRestfulAPIAndWebAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        public IActionResult GetAllBooks() => Ok(_bookService.GetAllBooks());
    }
}