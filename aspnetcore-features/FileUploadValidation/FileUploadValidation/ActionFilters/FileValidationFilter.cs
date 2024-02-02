using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FileUploadValidation.ActionFilters
{
    public class FileValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IFormFile);

            var file = param.Value as IFormFile;

            if (file is null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }

            if (!IsFileExtensionAllowed(file.FileName))
            {
                context.Result = new BadRequestObjectResult("Invalid file type. Please upload a PDF, DOC, or DOCX file.");
                return;
            }

            if (!IsFileSizeWithinLimit(file, 1024 * 1024))
            {
                context.Result = new BadRequestObjectResult("File size exceeds the maximum allowed size (1 MB).");
                return;
            }

            if (FileWithSameNameExists(file.FileName))
            {
                context.Result = new BadRequestObjectResult("Duplicate file name detected. Please upload a file with a different name.");
                return;
            }
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
            return false;
        }
    }
}
