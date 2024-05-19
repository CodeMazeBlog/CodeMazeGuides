using System.Net;
using SimpleHTTPServer;

[TestClass]
public class ChunkUploadServerTests
{
    private HttpClientHandler clientHandler;

    [TestInitialize]
    public void TestInitialize()
    {
        clientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        };
    }

    [TestMethod]
    public async Task WhenCreatingAServer_ThenItStartsSuccessfully()
    {
        // Arrange
        int chunkSize = 1024 * 1024;
        int threadCount = 4;
        int port = 8090;

        var server = new ChunkUploadServer(chunkSize, threadCount);
        server.StartServer(port);

        // Act
        using var client = new HttpClient(clientHandler);
        var response = await client.GetAsync($"http://localhost:{port}/upload/");
        Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
    }

    [TestMethod]
    public async Task WhenUploadingLargeFiles_ThenShouldRejectLargeFilesExceedingChunkCapacityByThrowingException()
    {
        // Arrange
        int chunkSize = 1024 * 1024;
        int threadCount = 4;
        int port = 8091;
        long fileSize = (chunkSize * threadCount) + 1; // Exceeds total chunk size

        var server = new ChunkUploadServer(chunkSize, threadCount);
        server.StartServer(port);

        // Act
        using var client = new HttpClient(clientHandler);
        using var content = new ByteArrayContent(new byte[fileSize]);
        content.Headers.Add("X-Filename", "test.txt");
        var response = await client.PostAsync($"http://localhost:{port}/upload/", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [TestMethod]
    public async Task WhenUploadingAFile_ThenShouldProcessChunksWithMultipleThreads()
    {
        // Arrange
        int chunkSize = 1024 * 1024;
        int threadCount = 4;
        int port = 8092;
        long fileSize = chunkSize * threadCount;

        var server = new ChunkUploadServer(chunkSize, threadCount);
        server.StartServer(port);

        // Act
        using var client = new HttpClient(clientHandler);
        using var content = new ByteArrayContent(new byte[fileSize]);
        content.Headers.Add("X-Filename", "test.txt");
        var response = await client.PostAsync($"http://localhost:{port}/upload/", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
    }
}