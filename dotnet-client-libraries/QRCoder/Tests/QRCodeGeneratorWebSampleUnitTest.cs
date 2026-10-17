using Microsoft.AspNetCore.Mvc;
using QRCodeGeneratorWebSample;
using QRCodeGeneratorWebSample.Controllers;
using QRCodeGeneratorWebSample.Models;

namespace Tests;
public class QRCodeGeneratorWebSampleUnitTest
{
    private static HomeModel RenderIndex()
    {
        var db = new QrCodesDb();
        var controller = new HomeController(db);

        var viewResult = controller.Index() as ViewResult;

        Assert.NotNull(viewResult);
        var model = viewResult.Model as HomeModel;
        Assert.NotNull(model);

        return model;
    }

    [Fact]
    public void GivenARequest_WhenCallingIndex_ThenTheControllerRendersAViewWithQrCodes()
    {
        // Act.
        var model = RenderIndex();

        // Assert.
        Assert.NotNull(model.QRCodes);
        Assert.NotEmpty(model.QRCodes);
        foreach (var qrCode in from expectedKey in new[] { "Basic String", "SVG", "URL", "Phone Number", "Custom", "Branded" }
                               let qrCode = model.QRCodes[expectedKey]
                               select qrCode)
        {
            Assert.NotNull(qrCode);
        }
    }

    [Fact]
    public void GivenARequest_WhenCallingIndex_ThenThePngRendererProducesARealPng()
    {
        // Arrange.
        const string prefix = "data:image/png;base64,";

        // Act.
        var dataUri = RenderIndex().QRCodes["Basic String"];

        // Assert.
        Assert.StartsWith(prefix, dataUri);
        var bytes = Convert.FromBase64String(dataUri[prefix.Length..]);
        Assert.Equal(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, bytes[..8]);
    }

    [Fact]
    public void GivenARequest_WhenCallingIndex_ThenTheSvgRendererProducesAnSvgDocument()
    {
        // Arrange.
        const string prefix = "data:image/svg+xml,";

        // Act.
        var dataUri = RenderIndex().QRCodes["SVG"];

        // Assert.
        Assert.StartsWith(prefix, dataUri);
        var svg = Uri.UnescapeDataString(dataUri[prefix.Length..]);
        Assert.Contains("<svg", svg);
        Assert.Contains("</svg>", svg);
    }
}
