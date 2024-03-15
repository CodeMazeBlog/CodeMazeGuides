namespace Tests;

public class ContentDownloadServiceTests
{
    [Fact]
    public void WhenDownloadCalled_ThenWritesExpectedDownloadMessage()
    {
        // Arrange
        var testDateTime = DateTime.Now;
        var testFileId = 1;
        var expectedMessage = $"{testDateTime} - Download - File ID: {testFileId}";

        // Act
        var resultMessage = ContentDownloadService.GetMessage(testDateTime, testFileId);

        // Assert
        Assert.Equal(expectedMessage, resultMessage);
    }
}