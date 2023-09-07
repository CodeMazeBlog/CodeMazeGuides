using Content;

namespace Tests
{
    public class ContentDownloadServiceTests
    {
        [Fact]
        public void WhenDownloadCalled_ThenWritesExpectedDownloadMessage()
        {
            // Arrange
            DateTime testDateTime = DateTime.Now;
            int testFileId = 1;
            string expectedMessage = $"{testDateTime} - Download - File ID: {testFileId}";

            // Act
            string resultMessage = ContentDownloadService.GetMessage(testDateTime, testFileId);

            // Assert
            Assert.Equal(expectedMessage, resultMessage);
        }
    }
}