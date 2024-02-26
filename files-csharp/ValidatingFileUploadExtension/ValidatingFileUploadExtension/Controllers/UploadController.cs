using Microsoft.AspNetCore.Mvc;
using ValidatingFileUploadExtension.FileFormats;

namespace ValidatingFileUploadExtension.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly List<FileFormatDescriptor> acceptableFormats = [new Image(), new Pdf()];

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var fileExtension = Path.GetExtension(Path.GetFileName(file.FileName))[1..];
            var targetType = acceptableFormats.Where(x => x.IsIncludedExtention(fileExtension.ToLower())).FirstOrDefault();
            
            if (targetType is null)
            {
                return BadRequest(new Result(false, Status.NOT_SUPPORTED, $"{Status.NOT_SUPPORTED}"));
            }

            var result = targetType.Validate(file);
            
            return result.Acceptable ? Ok(result) : BadRequest(result);
        }
    }
}
