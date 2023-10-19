namespace Tests
{
    public class ContentUploadServiceTests
    {
        [Fact]
        public void WhenUploadCalled_ThenWritesExpectedUploadMessage()
        {
            // Arrange
            var testDateTime = DateTime.Now;
            var testFileId = 1;
            var expectedMessage = $"{testDateTime} - Upload - File ID: {testFileId}"; // \r\n for Windows line ending

            // Act
            var resultMessage = ContentUploadService.GetMessage(testDateTime, testFileId);

            // Assert
            Assert.Equal(expectedMessage, resultMessage);
        }
    }
}