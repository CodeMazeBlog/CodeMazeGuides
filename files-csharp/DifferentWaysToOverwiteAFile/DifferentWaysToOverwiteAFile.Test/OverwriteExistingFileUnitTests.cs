using DifferentWaysToOverwiteAFile.Examples;
using System.Text;

namespace DifferentWaysToOverwiteAFile.Test
{
    public class OverwriteExistingFileTests
    {

        [Test]
        public void UseWriteAllText_ShouldOverwriteTheFile()
        {
            var filePath = "content.txt";
            try
            {
                //Arrange
                var originalContent = "Hello, World!";
                var newContent = "Hello, Code Maze!";

                // Create the test file and write the original content
                File.WriteAllText(filePath, originalContent);

                //Act
                WriteAllText.OverwiteFile(filePath, newContent);
                var actualContent = File.ReadAllText(filePath);

                //Assert
                Assert.That(actualContent, Is.EqualTo(newContent));
            }
            finally
            {
                // Clean up - delete the test file
                File.Delete(filePath);
            }
        }

        [Test]
        public void UseWriteAllBytes_ShouldOverwriteTheFile()
        {
            var filePath = "content.txt";
            try
            {
                //Arrange
                var originalContent = "Hello, World!";
                var newContent = "Hello, Code Maze!";
                var newBytes = Encoding.UTF8.GetBytes(newContent);

                // Create the test file and write the original content
                File.WriteAllText(filePath, originalContent);

                //Act
                WriteAllBytes.OverwiteFile(filePath, newBytes);
                var actualContent = File.ReadAllText(filePath);

                //Assert
                Assert.That(actualContent, Is.EqualTo(newContent));
            }
            finally
            {
                // Clean up - delete the test file
                File.Delete(filePath);
            }
        }

        [Test]
        public void UseFileStreamWIthFileMode_ShouldOverwriteTheFile()
        {
            var filePath = "content.txt";
            try
            {
                //Arrange
                var originalContent = "Hello, World!";
                var newContent = "Hello, Code Maze!";
                var newBytes = Encoding.UTF8.GetBytes(newContent);

                // Create the test file and write the original content
                File.WriteAllText(filePath, originalContent);

                //Act
                FileStreamWithFileMode.OverwiteFile(filePath, newBytes);
                var actualContent = File.ReadAllText(filePath);

                //Assert
                Assert.That(actualContent, Is.EqualTo(newContent));
            }
            finally
            {
                // Clean up - delete the test file
                File.Delete(filePath);
            }
        }

        [Test]
        public void UseStreamWriterOverwrite_ShouldOverwriteTheFile()
        {
            var filePath = "content.txt";
            try
            {
                //Arrange
                var originalContent = "Hello, World!";
                var newContent = "Hello, Code Maze!";

                // Create the test file and write the original content
                File.WriteAllText(filePath, originalContent);

                //Act
                StreamWriterClass.OverwiteFile(filePath, newContent);
                var actualContent = File.ReadAllText(filePath);

                //Assert
                Assert.That(actualContent, Is.EqualTo(newContent));
            }
            finally
            {
                // Clean up - delete the test file
                File.Delete(filePath);
            }
        }

        [Test]
        public void UseStreamWriterAppend_ShouldAppendTextToFile()
        {
            var filePath = "content.txt";
            try
            {
                //Arrange
                var originalContent = "Hello, World!";
                var newContent = "Hello, Code Maze!";
                var expectedContent = "Hello, World!Hello, Code Maze!";

                // Create the test file and write the original content
                File.WriteAllText(filePath, originalContent);

                //Act
                StreamWriterClass.AppendFile(filePath, newContent);
                var actualContent = File.ReadAllText(filePath);

                //Assert
                Assert.That(actualContent, Is.EqualTo(expectedContent));
            }
            finally
            {
                // Clean up - delete the test file
                File.Delete(filePath);
            }
        }
    }
}