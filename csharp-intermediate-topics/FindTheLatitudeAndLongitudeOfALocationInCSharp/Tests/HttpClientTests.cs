namespace Tests;
public class HttpClientTests
{
    [Fact]
    public async Task GivenInvalidAddress_WhenGetLatLongWithHttpClientCalled_ThenReturnsErrorMessage()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("{\"status\":\"ZERO_RESULTS\"}"),
        };

        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
             "SendAsync",
             ItExpr.IsAny<HttpRequestMessage>(),
             ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(response)
           .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://maps.googleapis.com/"),
        };

        var apiKey = "api_key_placeholder";
        var serviceUnderTest = new LatLongWithHttpClient(httpClient, apiKey);

        var invalidAddress = "Invalid Address";

        var result = await serviceUnderTest.GetLatLongWithHttpClient(invalidAddress);

        Assert.StartsWith("Error retrieving coordinates:", result);
    }

    [Fact]
    public async Task GivenAddress_WhenGetLatLongWithHttpClientCalled_ThenRequestUriIsCorrectlyFormatted()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var validAddress = "123 Main Street";
        var apiKey = "api_key_placeholder";
        Uri expectedUri = new($"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(validAddress)}&key={apiKey}");

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"status\":\"OK\",\"results\":[{\"geometry\":{\"location\":{\"lat\":40.7128,\"lng\":-74.0060}}}]}"),
            })
            .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://maps.googleapis.com/"),
        };

        var serviceUnderTest = new LatLongWithHttpClient(httpClient, apiKey);

        await serviceUnderTest.GetLatLongWithHttpClient(validAddress);

        handlerMock.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get &&
                req.RequestUri == expectedUri
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }


    [Fact]
    public async Task GivenServerError_WhenGetLatLongWithHttpClientCalled_ThenReturnsErrorMessage()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var responseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Content = new StringContent("Internal Server Error"),
        };

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(responseMessage);

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://maps.googleapis.com/"),
        };

        var serviceUnderTest = new LatLongWithHttpClient(httpClient, "api_key_placeholder");
        var validAddress = "123 Main Street";

        var result = await serviceUnderTest.GetLatLongWithHttpClient(validAddress);

        Assert.StartsWith("Error retrieving coordinates:", result);
    }
}