using BuildQueryString;
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

        [HttpGet("product")]
        public ActionResult GetProduct([FromQuery] Product product)
        {
            
            return Ok(product);
        }

        [HttpGet("person")]
        public ActionResult GetPerson([FromQuery] Person person)
        {
           
            return Ok(person);
        }
    }
}