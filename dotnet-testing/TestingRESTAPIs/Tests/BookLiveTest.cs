using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
internal record Book(int BookId, string Title);

public class BookLiveTest : IDisposable
{
    private const string _jsonMediaType = "application/json";
    private const int _expectedMaxElapsedMilliseconds = 1000;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://localhost:7133")
    };

    public void Dispose()
    {
        _httpClient.DeleteAsync("/state").GetAwaiter().GetResult();
    }

    private async Task AssertResponseWithContentAsync<T>(Stopwatch stopwatch,
                                                         HttpResponseMessage response,
                                                         System.Net.HttpStatusCode expectedStatusCode,
                                                         T expectedContent)
    {
        AssertCommonResponseParts(stopwatch,
                                  response,
                                  expectedStatusCode);
        Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);
        Assert.Equal(expectedContent, await JsonSerializer.DeserializeAsync<T?>(await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions));
    }

    private static void AssertCommonResponseParts(Stopwatch stopwatch,
                                                  HttpResponseMessage response,
                                                  System.Net.HttpStatusCode expectedStatusCode)
    {
        Assert.Equal(expectedStatusCode, response.StatusCode);
        Assert.True(stopwatch.ElapsedMilliseconds < _expectedMaxElapsedMilliseconds);
    }

    [Fact]
    public async Task GivenARequest_GetBooks_ReturnsExpectedResponse()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        var expectedContent = new[]
        {
            new Book(1, "Awesome book #1"),
            new Book(2, "Awesome book #2"),
            new Book(3, "Awesome book #3"),
            new Book(4, "Awesome book #4"),
            new Book(5, "Awesome book #5")
        };
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.GetAsync("/books");

        // Assert.
        await AssertResponseWithContentAsync(stopwatch,
                                             response,
                                             expectedStatusCode,
                                             expectedContent);
    }

    [Fact]
    public async Task GivenARequest_PostBooks_ReturnsExpectedResponseAndAddsBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Created;
        var expectedContent = new Book(6, "Awesome book #6");
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.PostAsync("/books", new StringContent(JsonSerializer.Serialize(expectedContent), Encoding.UTF8, _jsonMediaType));

        // Assert.
        await AssertResponseWithContentAsync(stopwatch,
                                             response,
                                             expectedStatusCode,
                                             expectedContent);
    }

    [Fact]
    public async Task GivenARequest_PutBooks_ReturnsExpectedResponseAndUpdatesBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        var expectedContent = new Book(6, "Awesome book #6 - Updated");
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.PutAsync("/books", new StringContent(JsonSerializer.Serialize(expectedContent), Encoding.UTF8, _jsonMediaType));

        // Assert.
        await AssertResponseWithContentAsync(stopwatch,
                                             response,
                                             expectedStatusCode,
                                             expectedContent);
    }

    [Fact]
    public async Task GivenARequest_DeleteBooks_ReturnsExpectedResponseAndDeletesBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.NoContent;
        var bookIdToDelete = 1;
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.DeleteAsync($"/books/{bookIdToDelete}");

        // Assert.
        AssertCommonResponseParts(stopwatch,
                                  response,
                                  expectedStatusCode);
    }

    [Fact]
    public async Task GivenAnAuthenticatedRequest_Admin_ReturnsExpectedResponse()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        var expectedContent = "Hi admin!";
        var stopwatch = Stopwatch.StartNew();
        var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
        request.Headers.Add("X-Api-Key", "SuperSecretApiKey");

        // Act.
        var response = await _httpClient.SendAsync(request);

        // Assert.
        await AssertResponseWithContentAsync(stopwatch,
                                             response,
                                             expectedStatusCode,
                                             expectedContent);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("WrongApiKey")]
    public async Task GivenAnUnauthenticatedRequest_Admin_ReturnsUnauthorized(string apiKey)
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Unauthorized;
        var stopwatch = Stopwatch.StartNew();
        var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
        request.Headers.Add("X-Api-Key", apiKey);

        // Act.
        var response = await _httpClient.SendAsync(request);

        // Assert.
        AssertCommonResponseParts(stopwatch,
                                  response,
                                  expectedStatusCode);
    }
}