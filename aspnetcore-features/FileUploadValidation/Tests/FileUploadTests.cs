using FileUploadValidation.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class FileUploadTests
    {

        [Fact]
        public void WhenUploadingFile_WithInvalidExtension_ThenFilterShouldReturnBadRequest()
        {
            var content = "Hello World from a Fake File";
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            // Arrange 
            var validateUserRoleActionFilter =
                new FileValidationFilter([".pdf", ".doc", ".docx"], 1024 * 1024);
            var httpContext = new DefaultHttpContext();

            var actionContext = new ActionContext(httpContext, new(), new(), new());
            var actionExecutingContext = new ActionExecutingContext(actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?>() { { "UploadedFile", file } },
            controller: null);

            // Act
            validateUserRoleActionFilter.OnActionExecuting(actionExecutingContext);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionExecutingContext.Result);
        }

        [Fact]
        public void WhenUploadingFile_WithValidExtension_ThenFilterShouldReturnNull()
        {
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            // Arrange 
            var validateUserRoleActionFilter =
                new FileValidationFilter([".pdf", ".doc", ".docx"], 1024 * 1024);
            var httpContext = new DefaultHttpContext();

            var actionContext = new ActionContext(httpContext, new(), new(), new());
            var actionExecutingContext = new ActionExecutingContext(actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?>() { { "UploadedFile", file } },
            controller: null);

            // Act
            validateUserRoleActionFilter.OnActionExecuting(actionExecutingContext);

            // Assert
            Assert.Null(actionExecutingContext.Result);
        }

        [Fact]
        public void WhenUploadingFile_WithSizeThatExceedsTheLimit_ThenShouldReturnBadRequest()
        {
            var content = new String('a', 1024 * 1024 * 10);
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            // Arrange 
            var validateUserRoleActionFilter =
                new FileValidationFilter([".pdf", ".doc", ".docx"], 1024 * 1024);
            var httpContext = new DefaultHttpContext();

            var actionContext = new ActionContext(httpContext, new(), new(), new());
            var actionExecutingContext = new ActionExecutingContext(actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?>() { { "UploadedFile", file } },
            controller: null);

            // Act
            validateUserRoleActionFilter.OnActionExecuting(actionExecutingContext);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionExecutingContext.Result);
        }
    }
}