using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FileUploadValidation.ActionFilters
{
    public class FileValidationFilter(string[] allowedExtensions, long maxSize) : ActionFilterAttribute
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

            if (!FileValidator.IsFileExtensionAllowed(file.FileName, allowedExtensions))
            {
                context.Result = new BadRequestObjectResult("Invalid file type. Please upload a PDF, DOC, or DOCX file.");
                return;
            }

            if (!FileValidator.IsFileSizeWithinLimit(file, maxSize))
            {
                context.Result = new BadRequestObjectResult("File size exceeds the maximum allowed size (1 MB).");
                return;
            }

            if (FileValidator.FileWithSameNameExists(file.FileName))
            {
                context.Result = new BadRequestObjectResult("Duplicate file name detected. Please upload a file with a different name.");
                return;
            }
        }
    }
}
