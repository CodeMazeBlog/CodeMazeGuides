namespace Tests.Services;

public class ExceptionsForFlowControlContactServiceTests
{
    private readonly ExceptionsForFlowControlContactService _contactService = new(new InMemoryContactRepository());

    [Fact]
    public void GetById_ForNonExistingContact_ThrowsRecordNotFoundException()
    {
        var exception = Assert.Throws<RecordNotFoundException>(() => _contactService.GetById(Guid.Empty));

        Assert.Equal($"contact with id {Guid.Empty} not found", exception.Message);
    }

    [Fact]
    public void Create_WithExistingEmail_ThrowsConflictException()
    {
        Assert.Throws<ConflictException>(() => _contactService.Create(new CreateContactDto("jdoe@unknown.com")));
    }

    [Fact]
    public void Create_WithNewEmail_ReturnsCreatedContact()
    {
        var contactDto = _contactService.Create(new CreateContactDto("asmith@unknown.com"));

        Assert.NotEqual(Guid.Empty, contactDto.Id);
        Assert.Equal("asmith@unknown.com", contactDto.Email);
    }
}
