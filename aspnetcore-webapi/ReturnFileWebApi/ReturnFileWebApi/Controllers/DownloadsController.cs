using Microsoft.AspNetCore.Mvc;
using ReturnFileWebApi.Interface;

namespace ReturnFileWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DownloadsController(IFileService fileService) : ControllerBase
{
    private readonly IFileService _fileService = fileService;
    private const string MimeType = "image/png";
    private const string FileName = "CM-Logo.png";

    [HttpGet("images-byte")]
    public IActionResult ReturnByteArray()
    {
        var image = _fileService.GetImageAsByteArray();

        return File(image, MimeType, FileName);
    }

    [HttpGet("images-stream")]
    public IActionResult ReturnStream()
    {
        var image = _fileService.GetImageAsStream();

        return File(image, MimeType, FileName);
    }

    [HttpGet("images-stream-range")]
    public IActionResult ReturnStreamWithRanges()
    {
        var image = _fileService.GetImageAsStream();

        return File(image, MimeType, FileName, enableRangeProcessing: true);
    }
}
