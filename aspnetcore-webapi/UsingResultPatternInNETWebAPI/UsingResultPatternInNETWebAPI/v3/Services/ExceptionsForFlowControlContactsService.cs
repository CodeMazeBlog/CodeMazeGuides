namespace UsingResultPatternInNETWebAPI.v3.Services;

public class ExceptionsForFlowControlContactsService
{
    private readonly IContactsRepository _contactsRepository;

    public ExceptionsForFlowControlContactsService(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public IEnumerable<ContactDto> GetAll()
    {
        return _contactsRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email));
    }

    public ContactDto GetById(Guid id)
    {
        var contact = _contactsRepository.GetById(id);

        if (contact is null)
        {
            throw new ApiNotFoundException(id);
        }

        return new ContactDto(contact.Id, contact.Email);
    }

    public ContactDto Create(CreateContactDto createContactDto)
    {
        if (_contactsRepository.ExistsByEmail(createContactDto.Email))
        {
            throw new ApiValidationException("contact with this email already exists");
        }

        var contact = new Contact
        {
            Email = createContactDto.Email
        };

        var createdContact = _contactsRepository.Create(contact);

        return new ContactDto(createdContact.Id, createdContact.Email);
    }
}