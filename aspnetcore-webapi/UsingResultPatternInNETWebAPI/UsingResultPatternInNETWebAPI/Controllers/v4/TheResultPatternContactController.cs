namespace UsingResultPatternInNETWebAPI.v4.Controllers;

[ApiController]
[Route("api/v4/contacts")]
public class TheResultPatternContactController : ControllerBase
{
    private readonly TheResultPatternContactService _contactService;

    public TheResultPatternContactController(TheResultPatternContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactService.GetAll();
        
        return Ok(contactDtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<ContactDto> GetById(Guid id)
    {
        var result = _contactService.GetById(id);

        if (result.IsFailure)
        {
            return NotFound(result.Error.Message);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var result = _contactService.Create(createContactDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error.Message);
        }

        var contactDto = result.Value;

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}