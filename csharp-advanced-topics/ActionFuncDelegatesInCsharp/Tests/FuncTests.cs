namespace Tests;

[TestClass]
public class FuncTests
{
    // Define the methods being tested
    private static int Addition(int x, int y)
    {
        return x + y;
    }

    private static string DisplayAddition(int a, int b)
    {
        return $"Addition of {a} and {b} is {a + b}";
    }

    private static string ShowCompleteName(string firstName, string lastName)
    {
        return $"Author of this Article is {firstName} {lastName}";
    }

    [TestMethod]
    public void GivenTwoIntegers_WhenCalculatingSum_ThenReturnExpectedSum()
    {
        // Arrange
        int x = 3;
        int y = 4;
        int expectedSum = 7;

        // Act
        int actualSum = Addition(x, y);

        // Assert
        Assert.AreEqual(expectedSum, actualSum);
    }

    [TestMethod]
    public void GivenTwoIntegers_WhenDisplayingAddition_ThenReturnExpectedMessage()
    {
        // Arrange
        int a = 5;
        int b = 6;
        string expectedMessage = $"Addition of {a} and {b} is {a + b}";

        // Act
        string actualMessage = DisplayAddition(a, b);

        // Assert
        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [TestMethod]
    public void GivenFirstAndLastName_WhenCreatingCompleteName_ThenReturnExpectedFullName()
    {
        // Arrange
        string firstName = "Code";
        string lastName = "Maze";
        string expectedFullName = $"Author of this Article is {firstName} {lastName}";

        // Act
        string actualFullName = ShowCompleteName(firstName, lastName);

        // Assert
        Assert.AreEqual(expectedFullName, actualFullName);
    }
}