namespace DifferentWaysToOverwriteAFile.Test;

public class OverwriteExistingFileTests
{
    private const string FilePath = "content.txt";

    [Test]
    public void GivenUseWriteAllText_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        const string newContent = "Hello, Code Maze!";

        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileWriter.OverwriteFileWithText(FilePath, newContent);
        var actualContent = File.ReadAllText(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenUseWriteAllBytes_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        byte[] newContent = { 56, 71, 21, 17, 32 };

        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileWriter.OverwriteFileWithBytes(FilePath, newContent);
        var actualContent = File.ReadAllBytes(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenUseFileStreamWIthFileMode_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        byte[] newContent = { 56, 71, 21, 17, 32 };

        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileStreamWithFileMode.OverwriteFile(FilePath, newContent);
        var actualContent = File.ReadAllBytes(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenUseStreamWriterOverwrite_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        const string newContent = "Hello, Code Maze!";

        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        StreamWriterClass.OverwriteFile(FilePath, newContent);
        var actualContent = File.ReadAllText(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenUseFileOpenWithFileMode_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        byte[] newContent = { 56, 71, 21, 17, 32 };

        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileOpenWithFileMode.OverwriteFile(FilePath, newContent);
        var actualContent = File.ReadAllBytes(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenUseStreamWriterAppend_ThenItShouldAppendTextToFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        const string newContent = "Hello, Code Maze!";
        const string expectedContent = originalContent + newContent;

        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        StreamWriterClass.AppendFile(FilePath, newContent);
        var actualContent = File.ReadAllText(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(expectedContent));
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(FilePath);
    }
}