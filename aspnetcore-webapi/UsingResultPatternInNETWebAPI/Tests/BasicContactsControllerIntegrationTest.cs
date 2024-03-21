namespace Tests;

public class BasicContactsControllerIntegrationTest : IClassFixture<ApiApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public BasicContactsControllerIntegrationTest(ApiApplicationFactory factory, ITestOutputHelper output)
    {
        _output = output;
        const string baseAddress = "http://localhost:5000/api/v1/contacts";

        _client = factory.CreateClient();
        _client.BaseAddress = new Uri(baseAddress);
    }

    [Fact]
    public async Task GivenBasicContactsController_WhenGetAll_ThenReturnOkStatusCode()
    {
        // Arrange
        // Act
        var response = await _client.GetAsync("");

        // Assert
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenBasicContactsController_WhenGetByIdForExistingContact_ThenReturnOkStatusCode()
    {
        // Arrange
        var baseUri = _client.BaseAddress! + "/";
        _client.BaseAddress = new Uri(baseUri);

        var existingId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // Act
        var response = await _client.GetAsync($"{existingId}");

        // Assert
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenBasicContactsController_WhenGetByIdForNonExistingContact_ThenReturnNoContent()
    {
        // Arrange
        var baseUri = _client.BaseAddress! + "/";
        _client.BaseAddress = new Uri(baseUri);

        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");

        // Act
        var response = await _client.GetAsync($"{nonExistingId}");

        // Assert
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task GivenBasicContactsController_WhenCreateContactWithValidEmail_ThenReturnCreatedStatusCode()
    {
        // Arrange
        var createContactDto = new CreateContactDto("asmith@unknown.com");

        // Act
        var response = await _client.PostAsJsonAsync("", createContactDto);

        // Assert
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GivenBasicContactsController_WhenCreateContactWithInvalidEmail_ThenReturnBadRequestStatusCode()
    {
        // Arrange
        var createContactDto = new CreateContactDto("NOT_AN_EMAIL");

        // Act
        var response = await _client.PostAsJsonAsync("", createContactDto);

        // Assert
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}