namespace Tests;

public class BasicContactsServiceIntegrationTest
{
    private readonly BasicContactsService _contactsService;

    public BasicContactsServiceIntegrationTest()
    {
        var repository = new InMemoryContactsRepository();
        _contactsService = new BasicContactsService(repository);
    }

    [Fact]
    public void GivenBasicContactsService_WhenGetAll_ThenReturnAllContacts()
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
    public void GivenBasicContactsService_WhenGetByIdForExistingContact_ThenReturnContact()
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
    public void GivenBasicContactsService_WhenGetByIdForNonExistingContact_ThenReturnNull()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");

        // Act
        var result = _contactsService.GetById(nonExistingId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GivenBasicContactsService_WhenCreateContactWithValidEmail_ThenReturnCreatedContact()
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
}