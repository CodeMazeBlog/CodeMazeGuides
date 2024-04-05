namespace UsingResultPatternInNETWebAPI.Controllers.v4;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactService.GetAll();
        
        return Ok(contactDtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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