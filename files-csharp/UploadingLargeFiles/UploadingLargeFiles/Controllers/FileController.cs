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

        [HttpPost("upload-stream-multipartreader")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [MultipartFormData]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> Upload()
        {
            var fileUploadSummary = await _fileService.UploadFileAsync(HttpContext.Request.Body, Request.ContentType);

            return CreatedAtAction(nameof(Upload), fileUploadSummary);
        }
    }
}