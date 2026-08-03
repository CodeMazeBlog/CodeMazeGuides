using Microsoft.AspNetCore.Mvc;
using Writer.Api.Repositories.Interfaces;

namespace Writer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterRepository _writerRepository;

        public WritersController(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_writerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var writer = _writerRepository.Get(id);

            if (writer is null)
                return NotFound();

            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Models.Writer writer)
        {
            var result = _writerRepository.Insert(writer);

            return Created($"/get/{result.Id}", result);
        }

    }
}
