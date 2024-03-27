namespace UsingResultPatternInNETWebAPI.Controllers.v1;

[ApiController]
[Route("api/v1/contacts")]
public class BasicContactController : ControllerBase
{
    private readonly BasicContactService _contactService;

    public BasicContactController(BasicContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactService.GetAll();
        
        return Ok(contactDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<ContactDto?> GetById(Guid id)
    {
        var contactDto = _contactService.GetById(id);

        return Ok(contactDto);
    }

    [HttpPost]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var contactDto = _contactService.Create(createContactDto);

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}