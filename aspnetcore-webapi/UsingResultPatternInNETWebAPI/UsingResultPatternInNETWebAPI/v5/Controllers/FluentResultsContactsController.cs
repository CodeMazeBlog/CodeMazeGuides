using System.Net;

namespace UsingResultPatternInNETWebAPI.v5.Controllers;

[ApiController]
[Route("api/v5/contacts")]
public class FluentResultsContactsController : ControllerBase
{
    private readonly FluentResultsContactsService _contactsService;

    public FluentResultsContactsController(FluentResultsContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var result = _contactsService.GetAll();

        if (result.IsFailed)
        {
            return Problem(detail: result.Errors[0].Message,
                statusCode: (int) HttpStatusCode.InternalServerError, 
                title: "Internal Server Error");
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<ContactDto> GetById(Guid id)
    {
        var result = _contactsService.GetById(id);

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
        var result = _contactsService.Create(createContactDto);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return CreatedAtAction(nameof(GetById), new {id = result.Value.Id}, result.Value);
    }
}