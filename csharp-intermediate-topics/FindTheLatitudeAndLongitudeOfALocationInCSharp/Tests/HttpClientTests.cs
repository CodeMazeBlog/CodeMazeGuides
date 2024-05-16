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
           .ReturnsAsync(response);

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        var client = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://maps.googleapis.com/")
        };

        httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

        var apiKey = "api_key_placeholder";
        var serviceUnderTest = new LatLongWithHttpClient(httpClientFactoryMock.Object, apiKey);

        var invalidAddress = "Invalid Address";
        var exception = await Assert.ThrowsAsync<Exception>(() => serviceUnderTest.GetLatLongFromAddressAsync(invalidAddress));

        Assert.StartsWith("Error retrieving coordinates:", exception.Message);
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

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        var client = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("https://maps.googleapis.com/") };
        httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

        var apiKey = "api_key_placeholder";
        var serviceUnderTest = new LatLongWithHttpClient(httpClientFactoryMock.Object, apiKey);

        var validAddress = "123 Main Street";
        var exception = await Assert.ThrowsAsync<HttpRequestException>(() => serviceUnderTest.GetLatLongFromAddressAsync(validAddress));

        Assert.Contains("Internal Server Error", exception.Message);
    }
}