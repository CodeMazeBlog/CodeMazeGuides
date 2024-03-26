namespace UsingResultPatternInNETWebAPI.Controllers.v3;

[ApiController]
[Route("api/v3/contacts")]
public class ExceptionsForFlowControlContactController : ControllerBase
{
    private readonly ExceptionsForFlowControlContactService _contactService;

    public ExceptionsForFlowControlContactController(ExceptionsForFlowControlContactService contactService)
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
        try
        {
            var contactDto = _contactService.GetById(id);

            return Ok(contactDto);
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var contactDto = _contactService.Create(createContactDto);

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}