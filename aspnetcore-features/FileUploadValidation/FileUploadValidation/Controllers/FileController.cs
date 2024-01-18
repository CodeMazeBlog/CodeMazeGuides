using Microsoft.AspNetCore.Mvc;

namespace FileUploadValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost(nameof(Upload))]
        public IActionResult Upload(IFormFile file)
        {
            if (!IsFileExtensionAllowed(file.FileName))
                return BadRequest("Invalid file type. Please upload a PDF, DOC, or DOCX file.");

            else if (!IsFileSizeWithinLimit(file, 1024 * 1024)) // Checking for 1 MB
                return BadRequest("File size exceeds the maximum allowed size (1 MB).");

            else if (FileWithSameNameExists(file.FileName))
                return BadRequest("Duplicate file name detected. Please upload a file with a different name.");

            return Ok(); // The file has been uploaded
        }

        private bool IsFileExtensionAllowed(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };

            return allowedExtensions.Contains(extension);
        }

        private bool IsFileSizeWithinLimit(IFormFile file, long maxSizeInBytes)
        {
            return file.Length <= maxSizeInBytes;
        }

        private bool FileWithSameNameExists(string fileName)
        {
            // Implement logic to check if a file with the same name exists in the system
            // ...
            return false;
        }
    }
}
