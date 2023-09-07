using Content;

namespace Tests
{
    public class ContentUploadServiceTests
    {
        [Fact]
        public void WhenUploadCalled_ThenWritesExpectedUploadMessage()
        {
            // Arrange
            DateTime testDateTime = DateTime.Now;
            int testFileId = 1;
            string expectedMessage = $"{testDateTime} - Upload - File ID: {testFileId}"; // \r\n for Windows line ending

            // Act
            string resultMessage = ContentUploadService.GetMessage(testDateTime, testFileId);

            // Assert
            Assert.Equal(expectedMessage, resultMessage);
        }
    }
}