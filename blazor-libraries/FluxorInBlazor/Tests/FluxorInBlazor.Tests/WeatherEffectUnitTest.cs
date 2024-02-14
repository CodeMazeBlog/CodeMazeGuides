using System.Net;
using Fluxor;
using FluxorInBlazor.State.Weather;
using FluxorInBlazor.State.Weather.Actions;
using Moq;
using Moq.Protected;

namespace FluxorInBlazor.Tests;

public sealed class WeatherEffectUnitTest
{
    [Test]
    public async Task GivenWeatherEffect_WhenFetchDataActionIsDispatched_ThenShouldDispatchDataFetchedAction()
    {
        var dispatcherMock = new Mock<IDispatcher>();
        var http = SetupHttpClientMock();
        var effect = new Effects(http);
        
        await effect.HandleFetchDataAction(dispatcherMock.Object);
        
        dispatcherMock.Verify(x => x.Dispatch(It.Is<DataFetchedAction>(a => 
            a.Forecasts.Count() == 1 && 
            a.Forecasts.First().Date == new DateOnly(2021, 01, 01) && 
            a.Forecasts.First().TemperatureC == 20)), Times.Once);
    }

    private static HttpClient SetupHttpClientMock()
    {
        var httpHandlerMock = new Mock<HttpMessageHandler>();
        httpHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[{\"date\":\"2021-01-01\",\"temperatureC\":20,\"summary\":\"Warm\"}]"),
            });
        var http = new HttpClient(httpHandlerMock.Object);
        http.BaseAddress = new("http://localhost");
        return http;
    }
}