namespace UsingResultPatternInNETWebAPI.v1.Controllers;

[ApiController]
[Route("api/v1/contacts")]
public class BasicContactsController : ControllerBase
{
    private readonly BasicContactsService _contactsService;

    public BasicContactsController(BasicContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactsService.GetAll();
        
        return Ok(contactDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<ContactDto?> GetById(Guid id)
    {
        var contactDto = _contactsService.GetById(id);

        return Ok(contactDto);
    }

    [HttpPost]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var contactDto = _contactsService.Create(createContactDto);

        return CreatedAtAction(nameof(GetById), new {id = contactDto.Id}, contactDto);
    }
}