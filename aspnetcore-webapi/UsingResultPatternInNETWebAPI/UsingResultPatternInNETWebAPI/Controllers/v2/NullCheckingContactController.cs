using UsingResultPatternInNETWebAPI.Services;

namespace UsingResultPatternInNETWebAPI.Controllers.v2;

[ApiController]
[Route("api/v2/contacts")]
public class NullCheckingContactController : ControllerBase
{
    private readonly NullCheckingContactService _contactService;

    public NullCheckingContactController(NullCheckingContactService contactService)
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
        var contactDto = _contactService.GetById(id);

        if (contactDto is null)
        {
            return NotFound();
        }

        return Ok(contactDto);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var contactDto = _contactService.Create(createContactDto);

        if (contactDto is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}