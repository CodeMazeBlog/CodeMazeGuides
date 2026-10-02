using UsingResultPatternInNETWebAPI.TheResultPattern;

namespace Tests.Services;

public class TheResultPatternContactServiceTests
{
    private static readonly Guid ExistingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

    private readonly TheResultPatternContactService _contactService = new(new InMemoryContactRepository());

    [Fact]
    public void GetAll_ReturnsTheSeededContact()
    {
        var result = _contactService.GetAll();

        Assert.True(result.IsSuccess);
        Assert.Single(result.Value);
    }

    [Fact]
    public void GetById_ForExistingContact_ReturnsContact()
    {
        var result = _contactService.GetById(ExistingId);

        Assert.True(result.IsSuccess);
        Assert.Equal(ExistingId, result.Value.Id);
    }

    [Fact]
    public void GetById_ForNonExistingContact_ReturnsNotFoundError()
    {
        var result = _contactService.GetById(Guid.Empty);

        Assert.False(result.IsSuccess);
        Assert.Equal("Contact.NotFound", result.Error!.Code);
        Assert.Equal(ErrorType.NotFound, result.Error.Type);
        Assert.Throws<InvalidOperationException>(() => result.Value);
    }

    [Fact]
    public void Create_WithExistingEmail_ReturnsConflictError()
    {
        var result = _contactService.Create(new CreateContactDto("jdoe@unknown.com"));

        Assert.False(result.IsSuccess);
        Assert.Equal(ErrorType.Conflict, result.Error!.Type);
        Assert.Equal("contact with email jdoe@unknown.com already exists", result.Error.Description);
    }

    [Fact]
    public void Create_WithNewEmail_ReturnsCreatedContact()
    {
        var result = _contactService.Create(new CreateContactDto("asmith@unknown.com"));

        Assert.True(result.IsSuccess);
        Assert.Equal("asmith@unknown.com", result.Value.Email);
    }
}
