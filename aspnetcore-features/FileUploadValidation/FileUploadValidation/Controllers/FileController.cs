using FileUploadValidation.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost(nameof(Upload))]
        [FileValidationFilter([".pdf", ".doc", ".docx"], 1024 * 1024)]
        public IActionResult Upload(IFormFile file)
        {
            // Do something with the file
            return Ok();
        }

        [HttpPost(nameof(UploadWithHardcodedValidation))]
        public IActionResult UploadWithHardcodedValidation(IFormFile file)
        {
            // Do something with the file

            if (!FileValidator.IsFileExtensionAllowed(file.FileName, [".pdf", ".doc", ".docx"]))
            {
                return BadRequest("Invalid file type. Please upload a PDF, DOC, or DOCX file.");
            }

            if (!!FileValidator.IsFileSizeWithinLimit(file, 1024 * 1024))
            {
                return BadRequest("File size exceeds the maximum allowed size (1 MB).");
            }

            if (FileValidator.FileWithSameNameExists(file.FileName))
            {
                return BadRequest("Duplicate file name detected. Please upload a file with a different name.");
            }

            return Ok();
        }
    }
}
