using SaveListToFileInCSharp;

namespace Tests
{
    [TestClass]
    public class ListToFileWriterTests
    {
        [TestMethod]
        public void WhenWriteToFileWithStreamWriter_ThenFileShouldContainAllStrings()
        {
            // Arrange
            string path = "test.txt";
            List<string> animals = new List<string> { "cat", "dog", "bird" };
            ListToFileWriter writer = new ListToFileWriter();

            // Act
            writer.WriteToFileWithStreamWriter(path, animals);

            // Assert
            string[] lines = File.ReadAllLines(path);
            CollectionAssert.AreEqual(animals, lines);
        }

        [TestMethod]
        public async Task WhenWriteToFileWithStreamWriterAsync_ThenFileShouldContainAllStrings()
        {
            // Arrange
            string path = "test.txt";
            List<string> animals = new List<string> { "cat", "dog", "bird" };
            ListToFileWriter writer = new ListToFileWriter();

            // Act
            await writer.WriteToFileWithStreamWriterAsync(path, animals);

            // Assert
            string[] lines = File.ReadAllLines(path);
            CollectionAssert.AreEqual(animals, lines);
        }

        [TestMethod]
        public void WhenAppendToFileWithStreamWriter_ThenFileShouldContainAppendedStrings()
        {
            // Arrange
            string path = "test.txt";
            List<string> animals = new List<string> { "cat", "dog", "bird" };
            List<string> newAnimals = new List<string> { "elephant", "lion", "koala" };
            ListToFileWriter writer = new ListToFileWriter();

            // Act
            writer.WriteToFileWithStreamWriter(path, animals);
            writer.AppendToFileWithStreamWriter(path, newAnimals);

            // Assert
            string[] lines = File.ReadAllLines(path);
            CollectionAssert.AreEqual(animals.Concat(newAnimals).ToList(), lines);
        }

        [TestMethod]
        public void WhenWriteToFileWithFileClass_ThenFileShouldContainAllLines()
        {
            // Arrange
            var writer = new ListToFileWriter();
            var path = "test.txt";
            var animals = new List<string> { "cat", "dog", "bird" };

            // Act
            writer.WriteToFileWithFileClass(path, animals);

            // Assert
            var fileContent = File.ReadAllLines(path);
            CollectionAssert.AreEqual(animals, fileContent);
        }

        [TestMethod]
        public async Task WhenWriteToFileWithFileClassAsync_ThenFileShouldContainAllLines()
        {
            // Arrange
            var writer = new ListToFileWriter();
            var path = "test.txt";
            var animals = new List<string> { "cat", "dog", "bird" };

            // Act
            await writer.WriteToFileWithFileClassAsync(path, animals);

            // Assert
            var fileContent = await File.ReadAllLinesAsync(path);
            CollectionAssert.AreEqual(animals, fileContent);
        }

        [TestMethod]
        public void WhenAppendToFileWithFileClass_ThenFileShouldContainAppendedLines()
        {
            // Arrange
            var writer = new ListToFileWriter();
            var path = "test.txt";
            var existingAnimals = new List<string> { "cat", "dog" };
            var newAnimals = new List<string> { "bird", "fish" };
            var expectedAnimals = existingAnimals.Concat(newAnimals).ToList();
            File.WriteAllLines(path, existingAnimals);

            // Act
            writer.AppendToFileWithFileClass(path, newAnimals);

            // Assert
            var fileContent = File.ReadAllLines(path);
            CollectionAssert.AreEqual(expectedAnimals, fileContent);
        }

        [TestMethod]
        public async Task WhenAppendToFileWithFileClassAsync_ThenFileShouldContainAppendedLines()
        {
            // Arrange
            var writer = new ListToFileWriter();
            var path = "test.txt";
            var existingAnimals = new List<string> { "cat", "dog" };
            var newAnimals = new List<string> { "bird", "fish" };
            var expectedAnimals = existingAnimals.Concat(newAnimals).ToList();
            await File.WriteAllLinesAsync(path, existingAnimals);

            // Act
            await writer.AppendToFileWithFileClassAsync(path, newAnimals);

            // Assert
            var fileContent = await File.ReadAllLinesAsync(path);
            CollectionAssert.AreEqual(expectedAnimals, fileContent);
        }
    }
}