namespace UsingResultPatternInNETWebAPI.v4.Services;

public class TheResultPatternContactsService
{
    private readonly IContactsRepository _contactsRepository;

    public TheResultPatternContactsService(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public CustomResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactsRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email));

        return CustomResult<IEnumerable<ContactDto>>.Success(contactDtos);
    }

    public CustomResult<ContactDto> GetById(Guid id)
    {
        var contact = _contactsRepository.GetById(id);

        if (contact is null)
        {
            return CustomResult<ContactDto>.Failure(CustomError.NotFound(id));
        }

        return CustomResult<ContactDto>.Success(new ContactDto(contact.Id, contact.Email));
    }

    public CustomResult<ContactDto> Create(CreateContactDto createContactDto)
    {
        if (_contactsRepository.ExistsByEmail(createContactDto.Email))
        {
            return CustomResult<ContactDto>.Failure(CustomError.ValidationError(createContactDto.Email));
        }

        var contact = new Contact
        {
            Email = createContactDto.Email
        };

        var createdContact = _contactsRepository.Create(contact);

        return CustomResult<ContactDto>.Success(new ContactDto(createdContact.Id, createdContact.Email));
    }
}