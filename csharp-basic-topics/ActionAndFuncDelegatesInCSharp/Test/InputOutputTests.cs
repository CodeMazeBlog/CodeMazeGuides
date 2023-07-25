using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class InputOutputTests
{
    [TestMethod]
    public void Read_Write_ValidInput()
    {
        // Arrange
        var inputOutput = new InputOutput();
        var expectedInput = "Hello, world!";

        // Act
        inputOutput.Read(() => expectedInput);

        string output = null;
        inputOutput.Write((result) => output = result);

        // Assert
        Assert.AreEqual($"'{expectedInput}' has {expectedInput.Length} characters.", output);
    }

    [TestMethod]
    public void Read_Write_EmptyInput()
    {
        // Arrange
        var inputOutput = new InputOutput();
        var expectedInput = "";

        // Act
        inputOutput.Read(() => expectedInput);

        string output = null;
        inputOutput.Write((result) => output = result);

        // Assert
        Assert.AreEqual($"'' has 0 characters.", output);
    }

    [TestMethod]
    public void Read_Write_NullInput()
    {
        // Arrange
        var inputOutput = new InputOutput();

        // Act
        inputOutput.Read(() => null);

        string output = null;
        inputOutput.Write((result) => output = result);

        // Assert
        Assert.AreEqual($"'' has 0 characters.", output);
    }
}
