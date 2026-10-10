using UsingResultPatternInNETWebAPI.Errors;

namespace Tests.Services;

public class FluentResultsContactServiceTests
{
    private readonly FluentResultsContactService _contactService = new(new InMemoryContactRepository());

    [Fact]
    public void GetById_ForNonExistingContact_ReturnsRecordNotFoundError()
    {
        var result = _contactService.GetById(Guid.Empty);

        Assert.True(result.IsFailed);
        Assert.True(result.HasError<RecordNotFoundError>());
    }

    [Fact]
    public void Create_WithExistingEmail_ReturnsConflictError()
    {
        var result = _contactService.Create(new CreateContactDto("jdoe@unknown.com"));

        Assert.True(result.IsFailed);
        Assert.True(result.HasError<ConflictError>());
    }

    [Fact]
    public void Create_WithNewEmail_ReturnsCreatedContact()
    {
        var result = _contactService.Create(new CreateContactDto("asmith@unknown.com"));

        Assert.True(result.IsSuccess);
        Assert.Equal("asmith@unknown.com", result.Value.Email);
    }
}
