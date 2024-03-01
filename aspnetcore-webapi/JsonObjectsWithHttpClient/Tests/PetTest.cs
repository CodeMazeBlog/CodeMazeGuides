using System.Net;
using JsonObjectsWithHttpClient;
using Moq;
using Moq.Protected;

namespace Tests;

public class PetTest
{
    [Fact]
    public async void GivenPetObjectHasValues_WhenPostAsStringContentIsCalled_ThenPetResultIsReturned()
    {
        var HttpClientFactoryMock = new Mock<IHttpClientFactory>();
        var HttpMessageHandlerMock = new Mock<HttpMessageHandler>();

        HttpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\n  \"id\": 12,\n  \"name\": \"German Shepherd\"\n}")
            });

        var httpClientMock = new HttpClient(HttpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://mockdomain.mock")
        };

        HttpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>()))
            .Returns(httpClientMock);

        var successResult = await new PetService(HttpClientFactoryMock.Object)
            .PostAsStringContent();

        Assert.Equal(12, successResult.Id);

        Assert.Equal("German Shepherd", successResult.Name);
    }
}