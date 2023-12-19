namespace WriteFileToTempFolder.Test
{
    public class UnitTest1
    {
        [Fact]
        public void GivenCustomFileName_WhenSaving_TheContentIsAsExpected()
        {
            //Arrange
            var customTempFileName = "file.txt";

            //Act
            TempFileCreator.CreateTempFile(customTempFileName);

            //Assert
            var tempFileContent = File.ReadAllText(customTempFileName);
            Assert.Equal("Your message", tempFileContent);
        }

        [Fact]
        public void GivenSystemCreatedFileName_WhenSaving_TheContentIsAsExpected()
        {
            //Arrange
            var tempFile = System.IO.Path.GetTempFileName();

            //Act
            TempFileCreator.CreateTempFile(tempFile);

            //Assert
            var tempFileContent = File.ReadAllText(tempFile);
            Assert.Equal("Your message", tempFileContent);
        }

        [Fact]
        public void GivenSystemSpecialFolderAndCustomName_WhenSaving_TheContentIsAsExpected()
        {
            //Arrange
            var tempFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\text.txt";

            //Act
            TempFileCreator.CreateTempFile(tempFile);

            //Assert
            var tempFileContent = File.ReadAllText(tempFile);
            Assert.Equal("Your message", tempFileContent);
        }
    }
}