namespace Tests.Services;

public class TheResultPatternContactServiceTests
{
    private readonly TheResultPatternContactService _contactService;

    public TheResultPatternContactServiceTests()
    {
        var repository = new InMemoryContactRepository();
        _contactService = new TheResultPatternContactService(repository);
    }

    [Fact]
    public void GivenTheResultPatternContactsService_WhenGetAll_ThenReturnAllContacts()
    {
        // Arrange
        var existingContactsCount = 1;

        // Act
        var result = _contactService.GetAll();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(existingContactsCount, result.Value.Count());
        Assert.IsAssignableFrom<IEnumerable<ContactDto>>(result.Value);
    }

    [Fact]
    public void GivenTheResultPatternContactsService_WhenGetByIdForExistingContact_ThenReturnContact()
    {
        // Arrange
        var existingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // Act
        var result = _contactService.GetById(existingId);

        // Assert
        Assert.True(result.IsSuccess);
        var contactDto = result.Value;
        Assert.IsType<ContactDto>(contactDto);
        Assert.Equal(existingId, contactDto.Id);
        Assert.NotNull(contactDto.Email);
    }

    [Fact]
    public void GivenTheResultPatternContactsService_WhenGetByIdForNonExistingContact_ThenReturnNotFound()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");

        // Act
        var result = _contactService.GetById(nonExistingId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal($"contact with id {nonExistingId} not found", result.Error.Message);
    }

    [Fact]
    public void GivenTheResultPatternContactsService_WhenCreateContactWithValidEmail_ThenReturnCreatedContact()
    {
        // Arrange
        var createContactDto = new CreateContactDto("asmith@unknown.com");

        // Act
        var result = _contactService.Create(createContactDto);

        // Assert
        Assert.True(result.IsSuccess);
        var contactDto = result.Value;
        Assert.IsType<ContactDto>(contactDto);
        Assert.NotEqual(Guid.Empty, contactDto.Id);
        Assert.Equal(createContactDto.Email, contactDto.Email);
    }

    [Fact]
    public void GivenTheResultPatternContactsService_WhenCreateContactWithExistingEmail_ThenReturnValidationError()
    {
        // Arrange
        var createContactDto = new CreateContactDto("jdoe@unknown.com");

        // Act
        var result = _contactService.Create(createContactDto);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal($"contact with email {createContactDto.Email} already exists", result.Error.Message);
    }
}