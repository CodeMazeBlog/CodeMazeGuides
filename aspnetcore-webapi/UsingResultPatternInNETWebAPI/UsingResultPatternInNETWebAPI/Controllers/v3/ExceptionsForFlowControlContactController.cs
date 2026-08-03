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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var contactDto = _contactService.Create(createContactDto);

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}