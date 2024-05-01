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
    public async Task WhenCreatingAServer_ThenItStartsSuccessfullyAndRejectInvalidHTTPMethods()
    {
        // Arrange
        int chunkSize = 1024 * 1024;
        int threadCount = 4;
        int port = 8080;
        var server = new ChunkUploadServer(chunkSize, threadCount);

        // Act
        Task serverTask = server.StartServer(port);
        await Task.Delay(2000); // Allow some time for server to start

        // Assert
        using (var client = new HttpClient(clientHandler))
        {
            var response = await client.GetAsync($"http://localhost:{port}/upload/");
            Assert.AreEqual((int)HttpStatusCode.MethodNotAllowed, (int)response.StatusCode);
        }

        // Clean up
        serverTask.Dispose();
    }

    [TestMethod]
    [ExpectedException(typeof(HttpRequestException))]
    public async Task WhenUploadingLargeFiles_ShouldRejectLargeFilesExceedingChunkCapacityByThrowingException()
    {
        // Arrange
        int chunkSize = 1024 * 1024;
        int threadCount = 4;
        int port = 8080;
        long fileSize = (chunkSize * threadCount) + 1; // Exceeds total chunk size

        var server = new ChunkUploadServer(chunkSize, threadCount);
        _ = server.StartServer(port);
        await Task.Delay(2000); // Allow some time for server to start

        // Act
        using var client = new HttpClient(clientHandler);
        using var content = new ByteArrayContent(new byte[fileSize]);
        content.Headers.Add("X-Filename", "test.txt");
        var response = await client.PostAsync($"http://localhost:{port}/upload/", content);
    }

    [TestMethod]
    public async Task WhenUploadingAFile_ShouldProcessChunksWithMultipleThreads()
    {
        // Arrange
        int chunkSize = 1024 * 1024;
        int threadCount = 4;
        int port = 8080;
        long fileSize = chunkSize * threadCount;

        var server = new ChunkUploadServer(chunkSize, threadCount);
        Task serverTask = server.StartServer(port);
        await Task.Delay(2000);  // Allow some time for server to start

        // Act
        using (var client = new HttpClient(clientHandler))
        using (var content = new ByteArrayContent(new byte[fileSize]))
        {
            content.Headers.Add("X-Filename", "test.txt");
            var response = await client.PostAsync($"http://localhost:{port}/upload/", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            // Assert
            using var result = response.Content.ReadAsStream();
            using var reader = new StreamReader(result);
            var message = reader.ReadToEnd();
            Assert.AreEqual($"File 'test.txt' uploaded successfully...", message);
        }

        // Wait for the server task to complete
        await Task.Delay(2000);
        serverTask.Wait();
    }
}