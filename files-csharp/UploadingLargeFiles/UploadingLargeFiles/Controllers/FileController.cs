using Microsoft.AspNetCore.Mvc;
using UploadingLargeFiles.Services;
using UploadingLargeFiles.Utilities;

namespace UploadingLargeFiles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [HttpPost("upload")]
        [ContentTypeValidation]
        public async Task<IActionResult> Upload()
        {
           var fileUploadSummary = await _fileService.UploadFileAsync(HttpContext.Request.Body, Request.ContentType);

            return Ok(fileUploadSummary);
        }
    }
}