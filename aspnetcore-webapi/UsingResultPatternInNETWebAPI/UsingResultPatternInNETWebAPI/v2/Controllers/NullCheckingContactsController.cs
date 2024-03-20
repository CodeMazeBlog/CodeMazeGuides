namespace UsingResultPatternInNETWebAPI.v2.Controllers;

[ApiController]
[Route("api/v2/contacts")]
public class NullCheckingContactsController : ControllerBase
{
    private readonly NullCheckingContactsService _contactsService;

    public NullCheckingContactsController(NullCheckingContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactsService.GetAll();
        
        return Ok(contactDtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<ContactDto?> GetById(Guid id)
    {
        var contactDto = _contactsService.GetById(id);

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
        var contactDto = _contactsService.Create(createContactDto);

        if (contactDto is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}