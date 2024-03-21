namespace UsingResultPatternInNETWebAPI.v1.Services;

public class BasicContactsService
{
    private readonly IContactsRepository _contactsRepository;

    public BasicContactsService(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public IEnumerable<ContactDto> GetAll()
    {
        return _contactsRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email));
    }

    public ContactDto? GetById(Guid id)
    {
        var contact = _contactsRepository.GetById(id);

        if (contact is null) return null;

        return new ContactDto(contact.Id, contact.Email);
    }

    public ContactDto Create(CreateContactDto createContactDto)
    {
        var contact = new Contact
        {
            Email = createContactDto.Email
        };

        var createdContact = _contactsRepository.Create(contact);

        return new ContactDto(createdContact.Id, createdContact.Email);
    }
}