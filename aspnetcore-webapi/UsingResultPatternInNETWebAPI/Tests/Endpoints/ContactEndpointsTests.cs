namespace Tests.Endpoints;

public class ContactEndpointsTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private const string ExistingId = "ffffffff-ffff-ffff-ffff-ffffffffffff";
    private const string NonExistingId = "00000000-0000-0000-0000-000000000000";

    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GetAll_ReturnsOk(int version)
    {
        var response = await _client.GetAsync($"/api/v{version}/contacts", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GetById_ForExistingContact_ReturnsOk(int version)
    {
        var response = await _client.GetAsync(
            $"/api/v{version}/contacts/{ExistingId}", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.OK)]
    [InlineData(2, HttpStatusCode.NotFound)]
    [InlineData(3, HttpStatusCode.NotFound)]
    [InlineData(4, HttpStatusCode.NotFound)]
    [InlineData(5, HttpStatusCode.NotFound)]
    public async Task GetById_ForNonExistingContact_ReturnsTheVersionsStatusCode(
        int version, HttpStatusCode statusCode)
    {
        var response = await _client.GetAsync(
            $"/api/v{version}/contacts/{NonExistingId}", TestContext.Current.CancellationToken);

        Assert.Equal(statusCode, response.StatusCode);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task GetById_ForNonExistingContact_ReturnsProblemDetails(int version)
    {
        var response = await _client.GetAsync(
            $"/api/v{version}/contacts/{NonExistingId}", TestContext.Current.CancellationToken);

        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task Create_WithNewEmail_ReturnsCreated(int version)
    {
        var response = await _client.PostAsJsonAsync(
            $"/api/v{version}/contacts",
            new CreateContactDto($"asmith-v{version}@unknown.com"),
            TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task Create_WithInvalidEmail_ReturnsBadRequest(int version)
    {
        var response = await _client.PostAsJsonAsync(
            $"/api/v{version}/contacts",
            new CreateContactDto("NOT_AN_EMAIL"),
            TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.Created)]
    [InlineData(2, HttpStatusCode.BadRequest)]
    [InlineData(3, HttpStatusCode.Conflict)]
    [InlineData(4, HttpStatusCode.Conflict)]
    [InlineData(5, HttpStatusCode.Conflict)]
    public async Task Create_WithExistingEmail_ReturnsTheVersionsStatusCode(
        int version, HttpStatusCode statusCode)
    {
        var response = await _client.PostAsJsonAsync(
            $"/api/v{version}/contacts",
            new CreateContactDto("jdoe@unknown.com"),
            TestContext.Current.CancellationToken);

        Assert.Equal(statusCode, response.StatusCode);
    }
}
