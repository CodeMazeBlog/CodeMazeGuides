namespace UsingResultPatternInNETWebAPI.v4.Controllers;

[ApiController]
[Route("api/v4/contacts")]
public class TheResultPatternContactsController : ControllerBase
{
    private readonly TheResultPatternContactsService _contactsContactsService;

    public TheResultPatternContactsController(TheResultPatternContactsService contactsContactsService)
    {
        _contactsContactsService = contactsContactsService;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactsContactsService.GetAll();
        
        return Ok(contactDtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<ContactDto> GetById(Guid id)
    {
        var result = _contactsContactsService.GetById(id);

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
        var result = _contactsContactsService.Create(createContactDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error.Message);
        }

        var contactDto = result.Value;

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}