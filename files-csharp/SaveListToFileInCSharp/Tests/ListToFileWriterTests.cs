namespace Tests;

[TestClass]
public class ListToFileWriterTests
{
    private const string _testFilePath = "CodeMazeAnimals.txt";

    [TestMethod]
    public void WhenWriteToFileWithStreamWriter_ThenFileShouldContainAllStrings()
    {
        // Arrange
        var animals = new List<string> { "cat", "dog", "bird" };
        var writer = new ListToFileWriter();

        // Act
        writer.WriteToFileWithStreamWriter(_testFilePath, animals);

        // Assert
        var lines = File.ReadAllLines(_testFilePath);
        CollectionAssert.AreEqual(animals, lines);
    }

    [TestMethod]
    public async Task WhenWriteToFileWithStreamWriterAsync_ThenFileShouldContainAllStrings()
    {
        // Arrange
        var animals = new List<string> { "cat", "dog", "bird" };
        var writer = new ListToFileWriter();

        // Act
        await writer.WriteToFileWithStreamWriterAsync(_testFilePath, animals);

        // Assert
        var lines = File.ReadAllLines(_testFilePath);
        CollectionAssert.AreEqual(animals, lines);
    }

    [TestMethod]
    public void WhenAppendToFileWithStreamWriter_ThenFileShouldContainAppendedStrings()
    {
        // Arrange
        var animals = new List<string> { "cat", "dog", "bird" };
        var newAnimals = new List<string> { "elephant", "lion", "koala" };
        var writer = new ListToFileWriter();

        // Act
        writer.WriteToFileWithStreamWriter(_testFilePath, animals);
        writer.AppendToFileWithStreamWriter(_testFilePath, newAnimals);

        // Assert
        string[] lines = File.ReadAllLines(_testFilePath);
        CollectionAssert.AreEqual(animals.Concat(newAnimals).ToList(), lines);
    }

    [TestMethod]
    public void WhenWriteToFileWithFileClass_ThenFileShouldContainAllLines()
    {
        // Arrange
        var writer = new ListToFileWriter();
        var animals = new List<string> { "cat", "dog", "bird" };

        // Act
        writer.WriteToFileWithFileClass(_testFilePath, animals);

        // Assert
        var fileContent = File.ReadAllLines(_testFilePath);
        CollectionAssert.AreEqual(animals, fileContent);
    }

    [TestMethod]
    public async Task WhenWriteToFileWithFileClassAsync_ThenFileShouldContainAllLines()
    {
        // Arrange
        var writer = new ListToFileWriter();
        var animals = new List<string> { "cat", "dog", "bird" };

        // Act
        await writer.WriteToFileWithFileClassAsync(_testFilePath, animals);

        // Assert
        var fileContent = await File.ReadAllLinesAsync(_testFilePath);
        CollectionAssert.AreEqual(animals, fileContent);
    }

    [TestMethod]
    public void WhenAppendToFileWithFileClass_ThenFileShouldContainAppendedLines()
    {
        // Arrange
        var writer = new ListToFileWriter();
        var existingAnimals = new List<string> { "cat", "dog" };
        var newAnimals = new List<string> { "bird", "fish" };
        var expectedAnimals = existingAnimals.Concat(newAnimals).ToList();
        File.WriteAllLines(_testFilePath, existingAnimals);

        // Act
        writer.AppendToFileWithFileClass(_testFilePath, newAnimals);

        // Assert
        var fileContent = File.ReadAllLines(_testFilePath);
        CollectionAssert.AreEqual(expectedAnimals, fileContent);
    }

    [TestMethod]
    public async Task WhenAppendToFileWithFileClassAsync_ThenFileShouldContainAppendedLines()
    {
        // Arrange
        var writer = new ListToFileWriter();
        var existingAnimals = new List<string> { "cat", "dog" };
        var newAnimals = new List<string> { "bird", "fish" };
        var expectedAnimals = existingAnimals.Concat(newAnimals).ToList();
        await File.WriteAllLinesAsync(_testFilePath, existingAnimals);

        // Act
        await writer.AppendToFileWithFileClassAsync(_testFilePath, newAnimals);

        // Assert
        var fileContent = await File.ReadAllLinesAsync(_testFilePath);
        CollectionAssert.AreEqual(expectedAnimals, fileContent);
    }
}