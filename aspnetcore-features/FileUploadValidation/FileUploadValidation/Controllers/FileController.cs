using FileUploadValidation.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost(nameof(UploadFile))]
        [FileValidationFilter([".pdf", ".doc", ".docx"], 1024 * 1024)]
        public IActionResult UploadFile(IFormFile file)
        {
            // Do something with the file
            return Ok();
        }

        [HttpPost(nameof(Upload))]
        public IActionResult Upload(IFormFile file)
        {
            if (file is null || file.Length == 0) 
                return BadRequest("The file is null");

            if (!FileValidator.IsFileExtensionAllowed(file, [".pdf", ".doc", ".docx"]))
                return BadRequest("Invalid file type. Please upload a PDF, DOC, or DOCX file.");

            if (!FileValidator.IsFileSizeWithinLimit(file, 1024 * 1024)) 
                return BadRequest("File size exceeds the maximum allowed size (1 MB).");


            if (FileValidator.FileWithSameNameExists(file))
                return BadRequest("Duplicate file name detected. Please upload a file with a different name.");

            return Ok();
        }
    }
}
