namespace ReadATextFileWithoutSpecifyingFullLocationTests;

public class TestProgram
{
    [Fact]
    public void When_ValidFileNameIsProvidedInAppDomainBaseDirectory_Then_FileContentIsReturned()
    {
        // Arrange
        string fileName = "CodeMaze.txt";
        string expectedContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectory, fileName);
        File.WriteAllText(filePath, expectedContent); // Create a test file in AppDomain's base directory

        // Act
        string fileContent = Program.ReadFileUsingAppDomain(fileName);

        // Assert
        Assert.Equal(expectedContent, fileContent);

        // Cleanup
        File.Delete(filePath);
    }


    [Fact]
    public void When_ValidEmbeddedFileNameIsProvided_Then_FileContentIsReturned()
    {
        // Arrange
        string fileName = "CodeMaze.txt";
        string expectedContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        string directory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(directory, fileName);
        File.WriteAllText(filePath, expectedContent);

        // Act
        string fileContent = Program.ReadEmbeddedFile(fileName);

        // Assert
        Assert.Equal(expectedContent, fileContent);
    }


    [Fact]
    public void When_ValidFileNameIsProvided_Then_FileContentIsReturned()
    {
        // Arrange
        string fileName = "CodeMaze.txt";
        string expectedContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        string directory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(directory, fileName);
        File.WriteAllText(filePath, expectedContent); // Creating a test file

        // Act
        string fileContent = Program.ReadFileUsingDirectory(fileName);

        // Assert
        Assert.Equal(expectedContent, fileContent);

        // Cleanup
        File.Delete(filePath); 
    }
}