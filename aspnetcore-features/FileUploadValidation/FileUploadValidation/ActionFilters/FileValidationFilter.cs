using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FileUploadValidation.ActionFilters
{
    public class FileValidationFilter(string[] allowedExtensions, long maxSize) : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IFormFile);

            if (param.Value is not IFormFile file || file.Length == 0)
            {
                context.Result = new BadRequestObjectResult("File is null");
                return;
            }

            if (!FileValidator.IsFileExtensionAllowed(file, allowedExtensions))
            {
                var allowedExtensionsMessage = String.Join(", ", allowedExtensions).Replace(".", "").ToUpper();
                context.Result = new BadRequestObjectResult("Invalid file type. " +
                    $"Please upload {allowedExtensionsMessage} file.");

                return;
            }

            if (!FileValidator.IsFileSizeWithinLimit(file, maxSize))
            {
                var mbSize = (double)maxSize / 1024 / 1024;
                context.Result = new BadRequestObjectResult($"File size exceeds the maximum allowed size ({mbSize} MB).");

                return;
            }

            if (FileValidator.FileWithSameNameExists(file))
            {
                context.Result = new BadRequestObjectResult("Duplicate file name detected. " +
                    "Please upload a file with a different name.");

                return;
            }
        }
    }
}
