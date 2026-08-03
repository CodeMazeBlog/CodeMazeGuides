using Microsoft.AspNetCore.Mvc;

namespace ValidatingFileUploadExtension.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var result = FileValidator.Validate(file);

            return result.Acceptable ? Ok(result) : BadRequest(result);
        }
    }
}