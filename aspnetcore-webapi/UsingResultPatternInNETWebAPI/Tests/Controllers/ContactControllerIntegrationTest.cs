namespace Tests.Controllers;

public class ContactControllerTests : IClassFixture<ApiApplicationFactory>
{
    private readonly string _baseApiTemplate = "http://localhost:5000/api/v{0}/contacts";

    private readonly HttpClient _client;

    public ContactControllerTests(ApiApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GivenBasicContactsController_WhenGetAll_ThenReturnOkStatusCode(int version)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version);
        _client.BaseAddress = new Uri(baseUri);

        // Act
        var response = await _client.GetAsync("");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(1)]    
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GivenBasicContactsController_WhenGetByIdForExistingContact_ThenReturnOkStatusCode(int version)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version) + "/";
        _client.BaseAddress = new Uri(baseUri);

        var existingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // Act
        var response = await _client.GetAsync($"{existingId}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.NoContent)]    
    [InlineData(2, HttpStatusCode.NotFound)]
    [InlineData(3, HttpStatusCode.NotFound)]
    [InlineData(4, HttpStatusCode.NotFound)]
    [InlineData(5, HttpStatusCode.NotFound)]
    public async Task GivenBasicContactsController_WhenGetByIdForNonExistingContact_ThenReturnAppropriateStatusCode(
        int version, HttpStatusCode statusCode)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version) + "/";
        _client.BaseAddress = new Uri(baseUri);

        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");

        // Act
        var response = await _client.GetAsync($"{nonExistingId}");

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GivenBasicContactsController_WhenCreateContactWithValidEmail_ThenReturnCreatedStatusCode(
        int version)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version);
        _client.BaseAddress = new Uri(baseUri);

        var createContactDto = new CreateContactDto($"asmith-v{version}@unknown.com");

        // Act
        var response = await _client.PostAsJsonAsync("", createContactDto);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GivenBasicContactsController_WhenCreateContactWithInvalidEmail_ThenReturnBadRequestStatusCode(
        int version)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version);
        _client.BaseAddress = new Uri(baseUri);

        var createContactDto = new CreateContactDto("NOT_AN_EMAIL");

        // Act
        var response = await _client.PostAsJsonAsync("", createContactDto);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.Created)]
    [InlineData(2, HttpStatusCode.BadRequest)]
    [InlineData(3, HttpStatusCode.BadRequest)]
    [InlineData(4, HttpStatusCode.BadRequest)]
    [InlineData(5, HttpStatusCode.BadRequest)]
    public async Task GivenBasicContactsController_WhenCreateContactForExistingEmail_ThenReturnAppropriateStatusCode(
        int version, HttpStatusCode statusCode)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version);
        _client.BaseAddress = new Uri(baseUri);

        var createContactDto = new CreateContactDto("jdoe@unknown.com");

        // Act
        var response = await _client.PostAsJsonAsync("", createContactDto);

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
    }
}