namespace UsingResultPatternInNETWebAPI.Services;

public class NullCheckingContactService
{
    private readonly IContactRepository _contactRepository;

    public NullCheckingContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public IEnumerable<ContactDto> GetAll()
    {
        return _contactRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email));
    }

    public ContactDto? GetById(Guid id)
    {
        var contact = _contactRepository.GetById(id);

        if (contact is null)
        {
            return null;
        }

        return new ContactDto(contact.Id, contact.Email);
    }

    public ContactDto? Create(CreateContactDto createContactDto)
    {
        if (_contactRepository.GetByEmail(createContactDto.Email) is not null)
        {
            return null;
        }

        var contact = new Contact
        {
            Email = createContactDto.Email
        };

        var createdContact = _contactRepository.Create(contact);

        return new ContactDto(createdContact.Id, createdContact.Email);
    }
}