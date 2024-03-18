using Microsoft.AspNetCore.Mvc.Testing;
namespace Tests;

public class FileUploadLiveTest
{
    private readonly WebApplicationFactory<Program> _factory = new();
    [Fact]
    public async Task UploadEndpoint_ShouldReturnOk_WhenFileIsUploaded()
    {
        const string filePath = "test.txt";
        var fileStream = File.OpenRead(filePath);
        var streamContent = new StreamContent(fileStream);
        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
        var client = _factory.CreateClient();
        var formData = new MultipartFormDataContent();
        formData.Add(streamContent, "file", Path.GetFileName(filePath));
        var response = await client.PostAsync("/upload", formData);
        response.EnsureSuccessStatusCode();
        
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}