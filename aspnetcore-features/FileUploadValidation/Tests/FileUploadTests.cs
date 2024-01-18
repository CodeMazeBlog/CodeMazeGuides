using FileUploadValidation.Controllers;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Tests
{
    public class FileUploadTests
    {
        private readonly FileController _controller;
        public FileUploadTests()
        {
            _controller = new FileController();
        }

        [Fact]
        public void WhenUploadingFile_WithInvalidExtension_ThenShouldReturnBadRequest()
        {
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            // Act
            var result = _controller.Upload(file);
            
            var statusCode = (HttpStatusCode)result
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(result, null);

            // Then
            Assert.Equal(HttpStatusCode.BadRequest, statusCode);
        }

        [Fact]
        public void WhenUploadingFile_WithValidExtension_ThenShouldReturnOK()
        {
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            // Act
            var result = _controller.Upload(file);

            var statusCode = (HttpStatusCode)result
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(result, null);

            // Then
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}