using UsingResultPatternInNETWebAPI.TheResultPattern;

namespace UsingResultPatternInNETWebAPI.Services;

public class TheResultPatternContactService
{
    private readonly IContactRepository _contactRepository;

    public TheResultPatternContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public Result<List<ContactDto>> GetAll()
    {
        return _contactRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email))
            .ToList();
    }

    public Result<ContactDto> GetById(Guid id)
    {
        var contact = _contactRepository.GetById(id);

        if (contact is null)
        {
            return ContactErrors.NotFound(id);
        }

        return new ContactDto(contact.Id, contact.Email);
    }

    public Result<ContactDto> Create(CreateContactDto createContactDto)
    {
        if (_contactRepository.GetByEmail(createContactDto.Email) is not null)
        {
            return ContactErrors.EmailTaken(createContactDto.Email);
        }

        var contact = new Contact
        {
            Email = createContactDto.Email
        };

        var createdContact = _contactRepository.Create(contact);

        return new ContactDto(createdContact.Id, createdContact.Email);
    }
}
