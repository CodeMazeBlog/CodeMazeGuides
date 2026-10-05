using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ReturnFileWebApi.Assets;
using ReturnFileWebApi.Controllers;
using ReturnFileWebApi.Interface;

namespace Tests;

public class Tests
{
    private readonly IFileService _fileService = Substitute.For<IFileService>();

    public Tests()
    {
        _fileService.GetImageAsByteArray()
            .Returns(Convert.FromBase64String(Image.Base64Image));

        _fileService.GetImageAsStream()
            .Returns(new MemoryStream(Convert.FromBase64String(Image.Base64Image)));
    }

    [Fact]
    public void GivenAnImagesbyteRoute_WhenUsingByteArray_ThenReturnAFileToDownload()
    {
        var controller = new DownloadsController(_fileService);

        var result = Assert.IsType<FileContentResult>(controller.ReturnByteArray());

        Assert.Equal("image/png", result.ContentType);
        Assert.Equal("CM-Logo.png", result.FileDownloadName);
    }

    [Fact]
    public void GivenAnImagesStreamRoute_WhenUsingStream_ThenReturnAFileToDownload()
    {
        var controller = new DownloadsController(_fileService);

        var result = Assert.IsType<FileStreamResult>(controller.ReturnStream());

        Assert.Equal("image/png", result.ContentType);
        Assert.Equal("CM-Logo.png", result.FileDownloadName);
    }

    [Fact]
    public void GivenAnImagesStreamRangeRoute_WhenUsingStream_ThenEnableRangeProcessing()
    {
        var controller = new DownloadsController(_fileService);

        var result = Assert.IsType<FileStreamResult>(controller.ReturnStreamWithRanges());

        Assert.True(result.EnableRangeProcessing);
        Assert.Equal("image/png", result.ContentType);
    }
}
