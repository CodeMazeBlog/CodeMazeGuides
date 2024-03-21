namespace Tests;

public class ExceptionsForFlowControlContactsServiceIntegrationTest
{
    private readonly ExceptionsForFlowControlContactsService _contactsService;

    public ExceptionsForFlowControlContactsServiceIntegrationTest()
    {
        var repository = new InMemoryContactsRepository();
        _contactsService = new ExceptionsForFlowControlContactsService(repository);
    }

    [Fact]
    public void GivenExceptionsForFlowControlContactsService_WhenGetAll_ThenReturnAllContacts()
    {
        // Arrange
        var existingContactsCount = 1;

        // Act
        var result = _contactsService.GetAll();

        // Assert
        Assert.Equal(existingContactsCount, result.Count());
        Assert.IsAssignableFrom<IEnumerable<ContactDto>>(result);
    }

    [Fact]
    public void GivenExceptionsForFlowControlContactsService_WhenGetByIdForExistingContact_ThenReturnContact()
    {
        // Arrange
        var existingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // Act
        var result = _contactsService.GetById(existingId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(existingId, result.Id);
        Assert.NotNull(result.Email);
    }

    [Fact]
    public void
        GivenExceptionsForFlowControlContactsService_WhenGetByIdForNonExistingContact_ThenThrowApiNotFoundException()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");
        var expectedExceptionMessage = $"contact with id {nonExistingId} was not found";

        // Act
        var act = () => _contactsService.GetById(nonExistingId);

        // Assert
        var exception = Assert.Throws<ApiNotFoundException>(act);
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [Fact]
    public void GivenExceptionsForFlowControlContactsService_WhenCreateContactWithValidEmail_ThenReturnCreatedContact()
    {
        // Arrange
        var createContactDto = new CreateContactDto("asmith@unknown.com");

        // Act
        var result = _contactsService.Create(createContactDto);

        // Assert
        Assert.NotNull(result);
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal(createContactDto.Email, result.Email);
    }

    [Fact]
    public void
        GivenExceptionsForFlowControlContactsService_WhenCreateContactWithExistingEmail_ThenThrowApiValidationException()
    {
        // Arrange
        var createContactDto = new CreateContactDto("jdoe@unknown.com");
        var expectedExceptionMessage = "contact with this email already exists";

        // Act
        var act = () => _contactsService.Create(createContactDto);

        // Assert
        var exception = Assert.Throws<ApiValidationException>(act);
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
}