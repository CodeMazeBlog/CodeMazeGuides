namespace Tests;

public class PetTest
{
    private const string _baseAddress = "https://mockdomain.mock";

    [Fact]
    public async void GivenPetObjectHasValues_WhenPostAsStringContentIsCalled_ThenPetResultIsReturned()
    {
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.RequestUri!.AbsoluteUri == $"{_baseAddress}/pet"), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\n  \"id\": 12,\n  \"name\": \"German Shepherd\"\n}")
            });

        var httpClientMock = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri(_baseAddress)
        };

        var successResult = await new PetService(httpClientMock)
            .PostAsStringContentAsync();

        Assert.NotNull(successResult);
        Assert.Equal(12, successResult!.Id);

        Assert.Equal("German Shepherd", successResult!.Name);
    }

    [Fact]
    public async void GivenPetObjectHasValues_WhenPostAsJsonIsCalled_ThenPetResultIsReturned()
    {
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.RequestUri!.AbsoluteUri == $"{_baseAddress}/pet"), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\n  \"id\": 12,\n  \"name\": \"German Shepherd\"\n}")
            });

        var httpClientMock = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri(_baseAddress)
        };
        
        var successResult = await new PetService(httpClientMock)
            .PostAsJsonAsync();

        Assert.NotNull(successResult);
        Assert.Equal(12, successResult!.Id);

        Assert.Equal("German Shepherd", successResult!.Name);
    }
}