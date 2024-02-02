using FileUploadValidation.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost(nameof(Upload))]
        [FileValidationFilter]
        public IActionResult Upload(IFormFile file)
        {
            // Do something with the file
            return Ok();
        }

        // Upload method without filters, commented to prevent rewrite of the validation methods

        //[HttpPost(nameof(Upload))]
        //public IActionResult Upload(IFormFile file)
        //{
        //    // Do something with the file

        //    if (!IsFileExtensionAllowed(file.FileName))
        //    {
        //        return BadRequest("Invalid file type. Please upload a PDF, DOC, or DOCX file.");
        //    }

        //    if (!IsFileSizeWithinLimit(file, 1024 * 1024))
        //    {
        //        return BadRequest("File size exceeds the maximum allowed size (1 MB).");
        //    }

        //    if (FileWithSameNameExists(file.FileName))
        //    {
        //        return BadRequest("Duplicate file name detected. Please upload a file with a different name.");
        //    }

        //    return Ok();
        //}
    }
}
