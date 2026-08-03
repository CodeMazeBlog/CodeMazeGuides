namespace Tests.Services;

public class FluentResultsContactServiceTests
{
    private readonly FluentResultsContactService _contactService;

    public FluentResultsContactServiceTests()
    {
        var repository = new InMemoryContactRepository();
        _contactService = new FluentResultsContactService(repository);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenGetAll_ThenReturnAllContacts()
    {
        // Arrange
        var existingContactsCount = 1;

        // Act
        var result = _contactService.GetAll();

        // Assert
        Assert.Equal(existingContactsCount, result.Value.Count());
        Assert.IsAssignableFrom<IEnumerable<ContactDto>>(result.Value);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenGetByIdForExistingContact_ThenReturnContact()
    {
        // Arrange
        var existingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // Act
        var result = _contactService.GetById(existingId);

        // Assert
        Assert.True(result.IsSuccess);
        var contact = result.Value;
        Assert.IsType<ContactDto>(contact);
        Assert.Equal(existingId, contact.Id);
        Assert.NotNull(contact.Email);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenGetByIdForNonExistingContact_ThenReturnFailure()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");
        var expectedError = new RecordNotFoundError($"contact with id {nonExistingId} not found");

        // Act
        var result = _contactService.GetById(nonExistingId);

        // Assert
        Assert.True(result.IsFailed);
        Assert.IsType<RecordNotFoundError>(result.Errors[0]);
        Assert.Equal(expectedError.Message, result.Errors[0].Message);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenCreateContactWithValidEmail_ThenReturnCreatedContact()
    {
        // Arrange
        var createContactDto = new CreateContactDto("asmith@unknown.com");

        // Act
        var result = _contactService.Create(createContactDto);

        // Assert
        Assert.True(result.IsSuccess);
        var contact = result.Value;
        Assert.IsType<ContactDto>(contact);
        Assert.NotEqual(Guid.Empty, contact.Id);
        Assert.Equal(createContactDto.Email, contact.Email);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenCreateContactWithExistingEmail_ThenReturnFailure()
    {
        // Arrange
        var createContactDto = new CreateContactDto("jdoe@unknown.com");
        var expectedError = new ValidationError("contact with this email already exists");

        // Act
        var result = _contactService.Create(createContactDto);

        // Assert
        Assert.True(result.IsFailed);
        Assert.IsType<ValidationError>(result.Errors[0]);
        Assert.Equal(expectedError.Message, result.Errors[0].Message);
    }
}