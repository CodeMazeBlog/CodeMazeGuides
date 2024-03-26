using UsingResultPatternInNETWebAPI.Services;

namespace UsingResultPatternInNETWebAPI.Controllers.v5;

[ApiController]
[Route("api/v5/contacts")]
public class FluentResultsContactController : ControllerBase
{
    private readonly FluentResultsContactService _contactService;

    public FluentResultsContactController(FluentResultsContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var result = _contactService.GetAll();

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<ContactDto> GetById(Guid id)
    {
        var result = _contactService.GetById(id);

        if (result.IsFailed)
        {
            return NotFound(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var result = _contactService.Create(createContactDto);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return CreatedAtAction(nameof(GetById), new {id = result.Value.Id}, result.Value);
    }
}