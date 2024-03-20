using UsingResultPatternInNETWebAPI.v5.Errors;
using UsingResultPatternInNETWebAPI.v5.Services;

namespace Tests;

public class FluentResultsContactsServiceIntegrationTest
{
    private readonly FluentResultsContactsService _contactsService;

    public FluentResultsContactsServiceIntegrationTest()
    {
        var repository = new InMemoryContactsRepository();
        _contactsService = new FluentResultsContactsService(repository);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenGetAll_ThenReturnAllContacts()
    {
        // Arrange
        var existingContactsCount = 1;

        // Act
        var result = _contactsService.GetAll();

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
        var result = _contactsService.GetById(existingId);

        // Assert
        Assert.True(result.IsSuccess);
        var contact = result.Value;
        Assert.Equal(existingId, contact.Id);
        Assert.NotNull(contact.Email);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenGetByIdForNonExistingContact_ThenReturnFailure()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");
        var expectedError = new ApiNotFoundError(nonExistingId);

        // Act
        var result = _contactsService.GetById(nonExistingId);

        // Assert
        Assert.True(result.IsFailed);
        Assert.IsType<ApiNotFoundError>(result.Errors[0]);
        Assert.Equal(expectedError.Message, result.Errors[0].Message);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenCreateContactWithValidEmail_ThenReturnCreatedContact()
    {
        // Arrange
        var createContactDto = new CreateContactDto("asmith@unknown.com");

        // Act
        var result = _contactsService.Create(createContactDto);

        // Assert
        Assert.True(result.IsSuccess);
        var contact = result.Value;
        Assert.NotEqual(Guid.Empty, contact.Id);
        Assert.Equal(createContactDto.Email, contact.Email);
    }

    [Fact]
    public void GivenFluentResultsContactsService_WhenCreateContactWithExistingEmail_ThenReturnFailure()
    {
        // Arrange
        var createContactDto = new CreateContactDto("jdoe@unknown.com");
        var expectedError = new ApiValidationError("contact with this email already exists");

        // Act
        var result = _contactsService.Create(createContactDto);

        // Assert
        Assert.True(result.IsFailed);
        Assert.IsType<ApiValidationError>(result.Errors[0]);
        Assert.Equal(expectedError.Message, result.Errors[0].Message);
    }
}