using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(string author, string language)
        {
            return Ok($"Author: {author}, Language:{language}");
        }
    }
}