namespace Tests.Services;

public class NullCheckingContactServiceTests
{
    private static readonly Guid ExistingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

    private readonly NullCheckingContactService _contactService = new(new InMemoryContactRepository());

    [Fact]
    public void GetById_ForExistingContact_ReturnsContact()
    {
        var contactDto = _contactService.GetById(ExistingId);

        Assert.NotNull(contactDto);
        Assert.Equal(ExistingId, contactDto.Id);
    }

    [Fact]
    public void GetById_ForNonExistingContact_ReturnsNull()
    {
        Assert.Null(_contactService.GetById(Guid.Empty));
    }

    [Fact]
    public void Create_WithExistingEmail_ReturnsNull()
    {
        Assert.Null(_contactService.Create(new CreateContactDto("jdoe@unknown.com")));
    }
}
