namespace Tests;

public class OtherContactsControllerIntegrationTest : IClassFixture<ApiApplicationFactory>
{
    private readonly string _baseApiTemplate = "http://localhost:5000/api/v{0}/contacts";

    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public OtherContactsControllerIntegrationTest(ApiApplicationFactory factory, ITestOutputHelper output)
    {
        _output = output;
        _client = factory.CreateClient();
    }

    [Theory]
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
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
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
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GivenBasicContactsController_WhenGetByIdForNonExistingContact_ThenReturnNotFoundStatusCode(
        int version)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version) + "/";
        _client.BaseAddress = new Uri(baseUri);

        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");

        // Act
        var response = await _client.GetAsync($"{nonExistingId}");

        // Assert
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
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
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Theory]
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
        var message = await response
            .Content
            .ReadAsStringAsync();
        _output.WriteLine(message);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GivenBasicContactsController_WhenCreateContactForExistingEmail_ThenReturnBadRequestStatusCode(
        int version)
    {
        // Arrange
        var baseUri = string.Format(_baseApiTemplate, version);
        _client.BaseAddress = new Uri(baseUri);

        var createContactDto = new CreateContactDto("jdoe@unknown.com");

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