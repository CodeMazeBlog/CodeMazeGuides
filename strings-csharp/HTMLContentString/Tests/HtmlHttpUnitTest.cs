using System.Net;
using HTMLContentString;
using Moq;
using Moq.Protected;

namespace Tests;

public class HtmlHttpUnitTest
{
    [Fact]
    public async Task WhenGetHtmlAsString_ThenStringResult()
    {
        var expected = "Expected HTML as a string response";
        var mockFactory = new Mock<IHttpClientFactory>();
        var mockMessageHandler = new Mock<HttpMessageHandler>();
        
        mockMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expected)
            });

        var httpClient = new HttpClient(mockMessageHandler.Object);

        mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
        
        var url = "https://www.wikipedia.org/";
        var http = new HtmlHttp(mockFactory.Object);
        var html = await http.GetHtmlAsStringAsync(url);
        
        Assert.NotNull(html);
        Assert.IsType<string>(html);
    }
}