using FluentResults;
using UsingResultPatternInNETWebAPI.Errors;

namespace UsingResultPatternInNETWebAPI.Services;

public class FluentResultsContactService
{
    private readonly IContactRepository _contactRepository;

    public FluentResultsContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public Result<List<ContactDto>> GetAll()
    {
        var contactDtos = _contactRepository
            .GetAll()
            .Select(c => new ContactDto(c.Id, c.Email))
            .ToList();

        return Result.Ok(contactDtos);
    }

    public Result<ContactDto> GetById(Guid id)
    {
        var contact = _contactRepository.GetById(id);

        if (contact is null)
        {
            return new RecordNotFoundError($"contact with id {id} not found");
        }

        return Result.Ok(new ContactDto(contact.Id, contact.Email));
    }

    public Result<ContactDto> Create(CreateContactDto contact)
    {
        if (_contactRepository.GetByEmail(contact.Email) is not null)
        {
            return new ConflictError($"contact with email {contact.Email} already exists");
        }

        var createdContact = _contactRepository.Create(new Contact { Email = contact.Email });

        return Result.Ok(new ContactDto(createdContact.Id, createdContact.Email));
    }
}
