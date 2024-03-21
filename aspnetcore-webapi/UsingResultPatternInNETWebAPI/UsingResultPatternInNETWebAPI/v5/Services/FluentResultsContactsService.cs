using UsingResultPatternInNETWebAPI.v5.Errors;

namespace UsingResultPatternInNETWebAPI.v5.Services;

public class FluentResultsContactsService
{
    private readonly IContactsRepository _contactsRepository;

    public FluentResultsContactsService(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public Result<IEnumerable<ContactDto>> GetAll()
    {
        var contactDtos = _contactsRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email));

        return Result.Ok(contactDtos);
    }

    public Result<Contact> GetById(Guid id)
    {
        var contact = _contactsRepository.GetById(id);

        if (contact is null)
        {
            return new ApiNotFoundError(id);
        }

        return Result.Ok(contact);
    }

    public Result<Contact> Create(CreateContactDto contact)
    {
        if (_contactsRepository.ExistsByEmail(contact.Email))
        {
            return new ApiValidationError("contact with this email already exists");
        }

        var createdContact = _contactsRepository.Create(new Contact {Email = contact.Email});

        return Result.Ok(createdContact);
    }
}