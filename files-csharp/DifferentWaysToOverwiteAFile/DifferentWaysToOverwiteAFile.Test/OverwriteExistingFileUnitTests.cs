namespace DifferentWaysToOverwiteAFile.Test;

public class OverwriteExistingFileTests
{
    private const string FilePath = "content.txt";

    [Test]
    public void UseWriteAllText_ShouldOverwriteTheFile()
    {
        try
        {
            //Arrange
            const string originalContent = "Hello, World!";
            const string newContent = "Hello, Code Maze!";

            //Assert that the file does not exist
            Assert.That(File.Exists(FilePath), Is.False);

            //Create the test file and write the original content
            File.WriteAllText(FilePath, originalContent);

            //Act
            FileWriter.OverwiteFileWithText(FilePath, newContent);
            var actualContent = File.ReadAllText(FilePath);

            //Assert
            Assert.That(actualContent, Is.EqualTo(newContent));
        }
        finally
        {
            //Clean up - delete the test file
            File.Delete(FilePath);
        }
    }

    [Test]
    public void UseWriteAllBytes_ShouldOverwriteTheFile()
    {
        const string filePath = "content.txt";
        try
        {
            //Arrange
            const string originalContent = "Hello, World!";
            byte[] newContent = { 56, 71, 21, 17, 32 };

            //Assert that the file does not exist
            Assert.That(File.Exists(filePath), Is.False);

            //Create the test file and write the original content
            File.WriteAllText(filePath, originalContent);

            //Act
            FileWriter.OverwiteFileWithBytes(filePath, newContent);
            var actualContent = File.ReadAllBytes(filePath);

            //Assert
            Assert.That(actualContent, Is.EqualTo(newContent));
        }
        finally
        {
            //Clean up - delete the test file
            File.Delete(filePath);
        }
    }

    [Test]
    public void UseFileStreamWIthFileMode_ShouldOverwriteTheFile()
    {
        const string filePath = "content.txt";
        try
        {
            //Arrange
            const string originalContent = "Hello, World!";
            byte[] newContent = { 56, 71, 21, 17, 32 };

            //Assert that the file does not exist
            Assert.That(File.Exists(filePath), Is.False);

            //Create the test file and write the original content
            File.WriteAllText(filePath, originalContent);

            //Act
            FileStreamWithFileMode.OverwiteFile(filePath, newContent);
            var actualContent = File.ReadAllBytes(filePath);

            //Assert
            Assert.That(actualContent, Is.EqualTo(newContent));
        }
        finally
        {
            //Clean up - delete the test file
            File.Delete(filePath);
        }
    }

    [Test]
    public void UseStreamWriterOverwrite_ShouldOverwriteTheFile()
    {
        const string filePath = "content.txt";
        try
        {
            //Arrange
            const string originalContent = "Hello, World!";
            const string newContent = "Hello, Code Maze!";

            //Assert that the file does not exist
            Assert.That(File.Exists(filePath), Is.False);

            //Create the test file and write the original content
            File.WriteAllText(filePath, originalContent);

            //Act
            StreamWriterClass.OverwiteFile(filePath, newContent);
            var actualContent = File.ReadAllText(filePath);

            //Assert
            Assert.That(actualContent, Is.EqualTo(newContent));
        }
        finally
        {
            //Clean up - delete the test file
            File.Delete(filePath);
        }
    }

    [Test]
    public void UseFileOpenWithFileMode_ShouldOverwriteTheFile()
    {
        const string filePath = "content.txt";
        try
        {
            //Arrange
            const string originalContent = "Hello, World!";
            byte[] newContent = { 56, 71, 21, 17, 32 };

            //Assert that the file does not exist
            Assert.That(File.Exists(filePath), Is.False);

            //Create the test file and write the original content
            File.WriteAllText(filePath, originalContent);

            //Act
            FileOpenWithFileMode.OverwriteFile(filePath, newContent);
            var actualContent = File.ReadAllBytes(filePath);

            //Assert
            Assert.That(actualContent, Is.EqualTo(newContent));
        }
        finally
        {
            //Clean up - delete the test file
            File.Delete(filePath);
        }
    }

    [Test]
    public void UseStreamWriterAppend_ShouldAppendTextToFile()
    {
        const string filePath = "content.txt";
        try
        {
            //Arrange
            const string originalContent = "Hello, World!";
            const string newContent = "Hello, Code Maze!";
            const string expectedContent = originalContent + newContent;

            //Assert that the file does not exist
            Assert.That(File.Exists(filePath), Is.False);

            //Create the test file and write the original content
            File.WriteAllText(filePath, originalContent);

            //Act
            StreamWriterClass.AppendFile(filePath, newContent);
            var actualContent = File.ReadAllText(filePath);

            //Assert
            Assert.That(actualContent, Is.EqualTo(expectedContent));
        }
        finally
        {
            //Clean up - delete the test file
            File.Delete(filePath);
        }
    }
}