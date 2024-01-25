using FileUploadValidation.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost(nameof(Upload))]
        [ServiceFilter(typeof(FileValidationFilter))]
        public IActionResult Upload(IFormFile file)
        {
            // Do something with the file
            return Ok();
        }
    }
}
