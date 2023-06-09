namespace Tests;

[TestClass]
public class FuncTests
{
    [TestMethod]
    public void GivenTwoIntegers_WhenDisplayingAddition_ThenReturnExpectedMessage()
    {
        // Arrange
        Func<int, int, string> completeName = FuncMethods.DisplayAddition;
        int a = 5;
        int b = 6;
        int sum = FuncMethods.Addition(a, b);
        string expected = $"Addition of {a} and {b} is {sum}";

        //// Act
        string actual = completeName(a, b);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GivenTwoIntegers_WhenCalculatingAddition_ThenReturnExpectedSum()
    {
        // Arrange
        Func<int, int, int> addition2 = FuncMethods.Addition;
        int num1 = 3;
        int num2 = 4;
        int expected = num1 + num2;

        // Act
        int actual = addition2(num1, num2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GivenTwoStrings_WhenShowingCompleteName_ThenReturnExpectedMessage()
    {
        // Arrange
        Func<string, string, string> completeName = FuncMethods.ShowCompleteName;
        string firstName = "Code";
        string lastName = "Maze";
        string expected = $"Author of this Article is {firstName} {lastName}";

        // Act
        string actual = completeName(firstName, lastName);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}