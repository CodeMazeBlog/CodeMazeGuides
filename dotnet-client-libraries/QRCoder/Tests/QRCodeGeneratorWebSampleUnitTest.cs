using Microsoft.AspNetCore.Mvc;
using QRCodeGeneratorWebSample;
using QRCodeGeneratorWebSample.Controllers;
using QRCodeGeneratorWebSample.Models;

namespace Tests;
public class QRCodeGeneratorWebSampleUnitTest
{
    [Fact]
    public void GivenARequest_WhenCallingIndex_ThenTheControllerRendersAViewWithQrCodes()
    {
        // Arrange.
        var db = new QrCodesDb();
        var controller = new HomeController(db);

        // Act.
        var viewResult = controller.Index() as ViewResult;

        // Assert.
        Assert.NotNull(viewResult);
        var model = viewResult.Model as HomeModel;
        Assert.NotNull(model);
        Assert.NotNull(model.QRCodes);
        Assert.NotEmpty(model.QRCodes);
        foreach (var qrCode in from expectedKey in new[] { "Basic String", "URL", "Phone Number", "Custom" }
                               let qrCode = model.QRCodes[expectedKey]
                               select qrCode)
        {
            Assert.NotNull(qrCode);
        }
    }
}