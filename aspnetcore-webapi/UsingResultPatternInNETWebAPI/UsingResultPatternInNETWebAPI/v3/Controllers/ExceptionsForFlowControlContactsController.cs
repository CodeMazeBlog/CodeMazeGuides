namespace UsingResultPatternInNETWebAPI.v3.Controllers;

[ApiController]
[Route("api/v3/contacts")]
public class ExceptionsForFlowControlContactsController : ControllerBase
{
    private readonly ExceptionsForFlowControlContactsService _contactsService;

    public ExceptionsForFlowControlContactsController(ExceptionsForFlowControlContactsService contactsService)
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
    public IActionResult GetById(Guid id)
    {
        try
        {
            var contactDto = _contactsService.GetById(id);

            return Ok(contactDto);
        }
        catch (ApiNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var contactDto = _contactsService.Create(createContactDto);

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}