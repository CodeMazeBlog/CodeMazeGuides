using DotNetURLShortener.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UrlShortenerWebAPI.Controllers;

namespace Tests;

public class URLShortenerControllerTest
{
    private readonly Mock<IUrlShortenerService> _mockService;
    private readonly URLShortenerController _controller;

    public URLShortenerControllerTest()
    {
        _mockService = new Mock<IUrlShortenerService>();
        _controller = new URLShortenerController(_mockService.Object);
    }

    [Fact]
    public void WhenPostLongUrlIsCalled_ThenReturnsShortUrl()
    {
        string expectedShortCode = "eW3Ta";
        string longUrl = "https://localhost:7075/testurlshortener";

        _mockService.Setup(service => service.GetShortCode(longUrl))
            .Returns(expectedShortCode);

        var result = _controller.ShortenUrl(longUrl);

        var actionResult = Assert.IsType<OkObjectResult>(result);
        var actualShortCode = Assert.IsType<string>(actionResult.Value);
        Assert.Equal(expectedShortCode, actionResult.Value);
        Assert.Equal(5, actualShortCode.Length);
    }

    [Fact]
    public void WhenGetLongUrlIsCalled_ThenRedirectsToTheLongUrl()
    {
        string shortCode = "eW3Ta";
        string expectedLongUrl = "https://localhost:7075/testurlshortener";

        _mockService.Setup(service => service.GetLongUrl(shortCode))
            .Returns(expectedLongUrl);

        var result = _controller.GetLongUrl(shortCode);

        var redirectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedLongUrl, redirectResult.Value);
    }
}