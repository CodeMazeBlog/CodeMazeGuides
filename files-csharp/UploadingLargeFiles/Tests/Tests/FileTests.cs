using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Tests
{
    public class FileTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FileTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task WhenUploadFileWithContentTypeHeaderAndFiles_ThenReturnRequestFulfilled()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            HttpResponseMessage response;
            await using (var file1 = File.OpenRead(@"Files\SampleDoc1.pdf"))
            using (var content1 = new StreamContent(file1))
            await using (var file2 = File.OpenRead(@"Files\SampleFile2.zip"))
            using (var content2 = new StreamContent(file2))
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(content1, "files", "SampleDoc1.pdf");
                formData.Add(content2, "files", "SampleFile2.zip");

                response = await client.PostAsync("/file/upload", formData);
            }

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenUploadFileWithContentTypeHeaderNoFiles_ThenReturnRequestFulfilled()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            HttpResponseMessage response;
            using (var formData = new MultipartFormDataContent())
            {
                var textContent = new StringContent("Just text");
                formData.Add(textContent, "text-sample");

                response = await client.PostAsync("/file/upload", formData);
            }

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenUploadFileWithoutContentTypeHeader_ThenReturnBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync("/file/upload", null);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}