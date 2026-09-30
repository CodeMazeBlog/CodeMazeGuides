using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;

namespace Tests
{
    public class MultipartFormDataTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public MultipartFormDataTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task WhenSendingMultiplePartsInPostRequest_ThenRequestIsSentSuccessfully()
        {
            using MultipartFormDataContent multipartContent = new();

            multipartContent.Add(new StringContent("John", Encoding.UTF8, MediaTypeNames.Text.Plain), "first_name");
            multipartContent.Add(new StringContent("Doe", Encoding.UTF8, MediaTypeNames.Text.Plain), "last_name");

            using var response = await _httpClient.PostAsync("http://localhost:5272/upload-form", multipartContent);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task WhenSendingFileInMultipartRequest_ThenRequestIsSentSuccessfully()
        {
            using MultipartFormDataContent multipartContent = new();

            var imageContent = new StreamContent(File.OpenRead("john_doe.jpg"));
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);

            multipartContent.Add(imageContent, "profile_picture", "john_doe.jpg");

            using var response = await _httpClient.PostAsync("http://localhost:5272/upload-image", multipartContent);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task WhenSendingByteArrayInMultipartRequest_ThenRequestIsSentSuccessfully()
        {
            using MultipartFormDataContent multipartContent = new();

            var byteArrayContent = new ByteArrayContent(await File.ReadAllBytesAsync("john_doe.jpg"));
            byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);

            multipartContent.Add(byteArrayContent, "profile_picture", "john_doe.jpg");

            using var response = await _httpClient.PostAsync("http://localhost:5272/upload-image", multipartContent);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task WhenSendingJsonPartInMultipartRequest_ThenPartCarriesJsonContentType()
        {
            using MultipartFormDataContent multipartContent = new();

            var jsonContent = JsonContent.Create(new { City = "Belgrade", Country = "Serbia" });

            multipartContent.Add(new StringContent("John", Encoding.UTF8, MediaTypeNames.Text.Plain), "first_name");
            multipartContent.Add(new StringContent("Doe", Encoding.UTF8, MediaTypeNames.Text.Plain), "last_name");
            multipartContent.Add(jsonContent, "address");

            Assert.Equal("application/json; charset=utf-8", jsonContent.Headers.ContentType?.ToString());

            using var response = await _httpClient.PostAsync("http://localhost:5272/upload-form", multipartContent);

            response.EnsureSuccessStatusCode();
        }
    }
}