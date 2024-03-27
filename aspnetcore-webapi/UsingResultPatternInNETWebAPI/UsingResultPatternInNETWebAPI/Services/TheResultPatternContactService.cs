namespace UsingResultPatternInNETWebAPI.Services;

public class TheResultPatternContactService
{
    private readonly IContactRepository _contactRepository;

    public TheResultPatternContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public CustomResult<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email));

        return CustomResult<IEnumerable<ContactDto>>.Success(contactDtos);
    }

    public CustomResult<ContactDto> GetById(Guid id)
    {
        var contact = _contactRepository.GetById(id);

        if (contact is null)
        {
            var message = $"contact with id {id} not found";
            return CustomResult<ContactDto>.Failure(CustomError.RecordNotFound(message));
        }

        return CustomResult<ContactDto>.Success(new ContactDto(contact.Id, contact.Email));
    }

    public CustomResult<ContactDto> Create(CreateContactDto createContactDto)
    {
        if (_contactRepository.GetByEmail(createContactDto.Email) is not null)
        {
            var message = $"contact with email {createContactDto.Email} already exists";
            return CustomResult<ContactDto>.Failure(CustomError.ValidationError(message));
        }

        var contact = new Contact
        {
            Email = createContactDto.Email
        };

        var createdContact = _contactRepository.Create(contact);

        return CustomResult<ContactDto>.Success(new ContactDto(createdContact.Id, createdContact.Email));
    }
}