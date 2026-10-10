namespace Tests;

public class PetTest
{
    private const string _baseAddress = "https://mockdomain.mock";

    private static (HttpClient Client, List<string?> ContentTypes) CreateClient()
    {
        var contentTypes = new List<string?>();
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.RequestUri!.AbsoluteUri == $"{_baseAddress}/pet"), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((request, _) => contentTypes.Add(request.Content?.Headers.ContentType?.ToString()))
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\n  \"id\": 12,\n  \"name\": \"German Shepherd\"\n}", Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri(_baseAddress)
        };

        return (httpClient, contentTypes);
    }

    [Fact]
    public async Task GivenPetObjectHasValues_WhenPostAsStringContentIsCalled_ThenPetResultIsReturned()
    {
        var (httpClient, contentTypes) = CreateClient();

        var successResult = await new PetService(httpClient)
            .PostAsStringContentAsync();

        Assert.NotNull(successResult);
        Assert.Equal(12, successResult!.Id);
        Assert.Equal("German Shepherd", successResult!.Name);
        Assert.Equal("application/json; charset=utf-8", Assert.Single(contentTypes));
    }

    [Fact]
    public async Task GivenPetObjectHasValues_WhenPostWithPostAsJsonIsCalled_ThenPetResultIsReturned()
    {
        var (httpClient, contentTypes) = CreateClient();

        var successResult = await new PetService(httpClient)
            .PostWithPostAsJsonAsync();

        Assert.NotNull(successResult);
        Assert.Equal(12, successResult!.Id);
        Assert.Equal("German Shepherd", successResult!.Name);
        Assert.Equal("application/json; charset=utf-8", Assert.Single(contentTypes));
    }

    [Fact]
    public async Task GivenPetObjectHasValues_WhenPostAsJsonContentIsCalled_ThenPetResultIsReturned()
    {
        var (httpClient, contentTypes) = CreateClient();

        var successResult = await new PetService(httpClient)
            .PostAsJsonContentAsync();

        Assert.NotNull(successResult);
        Assert.Equal(12, successResult!.Id);
        Assert.Equal("German Shepherd", successResult!.Name);
        Assert.Equal("application/json; charset=utf-8", Assert.Single(contentTypes));
    }

    [Fact]
    public async Task GivenPetObjectHasValues_WhenPostAsSourceGeneratedJsonIsCalled_ThenPetResultIsReturned()
    {
        var (httpClient, contentTypes) = CreateClient();

        var successResult = await new PetService(httpClient)
            .PostAsSourceGeneratedJsonAsync();

        Assert.NotNull(successResult);
        Assert.Equal(12, successResult!.Id);
        Assert.Equal("German Shepherd", successResult!.Name);
        Assert.Equal("application/json; charset=utf-8", Assert.Single(contentTypes));
    }

    [Fact]
    public void GivenStringContent_WhenMediaTypeIsOmitted_ThenContentTypeIsTextPlain()
    {
        var withoutMediaType = new StringContent("{}", Encoding.UTF8);
        var withMediaType = new StringContent("{}", Encoding.UTF8, "application/json");

        Assert.Equal("text/plain; charset=utf-8", withoutMediaType.Headers.ContentType!.ToString());
        Assert.Equal("application/json; charset=utf-8", withMediaType.Headers.ContentType!.ToString());
    }
}