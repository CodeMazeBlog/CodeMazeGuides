using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
internal record Book(int BookId, string Title);

public class BookLiveTest : IDisposable
{   
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://localhost:7133")
    };

    public void Dispose()
    {
        _httpClient.DeleteAsync("/state").GetAwaiter().GetResult();
    }

    [Fact]
    public async Task GivenARequest_WhenCallingGetBooks_ThenTheAPIReturnsExpectedResponse()
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
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

    [Fact]
    public async Task GivenARequest_WhenCallingPostBooks_ThenTheAPIReturnsExpectedResponseAndAddsBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Created;
        var expectedContent = new Book(6, "Awesome book #6");
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.PostAsync("/books", TestHelpers.GetJsonStringContent(expectedContent));

        // Assert.
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

    [Fact]
    public async Task GivenARequest_WhenCallingPutBooks_ThenTheAPIReturnsExpectedResponseAndUpdatesBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.NoContent;
        var updatedBook = new Book(6, "Awesome book #6 - Updated");
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.PutAsync("/books", TestHelpers.GetJsonStringContent(updatedBook));

        // Assert.
        TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
    }

    [Fact]
    public async Task GivenARequest_WhenCallingDeleteBooks_ThenTheAPIReturnsExpectedResponseAndDeletesBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.NoContent;
        var bookIdToDelete = 1;
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.DeleteAsync($"/books/{bookIdToDelete}");

        // Assert.
        TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
    }

    [Fact]
    public async Task GivenAnAuthenticatedRequest_WhenCallingAdmin_ThenTheAPIReturnsExpectedResponse()
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
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("WrongApiKey")]
    public async Task GivenAnUnauthenticatedRequest_WhenCallingAdmin_ThenTheAPIReturnsUnauthorized(string apiKey)
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Unauthorized;
        var stopwatch = Stopwatch.StartNew();
        var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
        request.Headers.Add("X-Api-Key", apiKey);

        // Act.
        var response = await _httpClient.SendAsync(request);

        // Assert.
        TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
    }
}