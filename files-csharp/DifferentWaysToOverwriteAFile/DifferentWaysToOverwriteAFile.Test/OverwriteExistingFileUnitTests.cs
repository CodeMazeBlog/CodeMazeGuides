namespace DifferentWaysToOverwriteAFile.Test;

public class OverwriteExistingFileTests
{
    private const string FilePath = "content.txt";

    [SetUp]
    public void Setup()
    {
        //Assert that the file does not exist
        Assert.That(File.Exists(FilePath), Is.False);
    }

    [Test]
    public void GivenFileWriterOverwriteFileWithText_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        const string newContent = "Hello, Code Maze!";

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileWriter.OverwriteFileWithText(FilePath, newContent);
        var actualContent = File.ReadAllText(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenFileWriterOverwriteFileWithBytes_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        byte[] newContent = { 56, 71, 21, 17, 32 };

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileWriter.OverwriteFileWithBytes(FilePath, newContent);
        var actualContent = File.ReadAllBytes(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenFileStreamWithFileModeOverwriteFile_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        byte[] newContent = { 56, 71, 21, 17, 32 };

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileStreamWithFileMode.OverwriteFile(FilePath, newContent);
        var actualContent = File.ReadAllBytes(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenStreamWriterOverwriteFile_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        const string newContent = "Hello, Code Maze!";

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        Examples.StreamWriter.OverwriteFile(FilePath, newContent);
        var actualContent = File.ReadAllText(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenFileOpenWithFileModeOverwriteFile_ThenItShouldOverwriteTheFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        byte[] newContent = { 56, 71, 21, 17, 32 };

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        FileOpenWithFileMode.OverwriteFile(FilePath, newContent);
        var actualContent = File.ReadAllBytes(FilePath);

        //Assert
        Assert.That(actualContent, Is.EqualTo(newContent));
    }

    [Test]
    public void GivenStreamWriterAppendFile_ThenItShouldAppendTextToFile()
    {
        //Arrange
        const string originalContent = "Hello, World!";
        const string newContent = "Hello, Code Maze!";
        const string expectedContent = originalContent + newContent;

        //Create the test file and write the original content
        File.WriteAllText(FilePath, originalContent);

        //Act
        Examples.StreamWriter.AppendFile(FilePath, newContent);
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