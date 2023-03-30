using ActionAndFuncInCsharp;
using System.Text;

namespace Tests;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestDifferenceBetweenTwoNumbers()
    {
        Func<int, int, int> SunstractionOfNumbers = Program.DifferenceBetweenTwoNumbers;

        int rest = SunstractionOfNumbers(9, 4);

        Assert.AreEqual(5, rest);
    }

    [TestMethod]
    public void TestSubstractionResultWithLambdaExpression()
    {
        // Act
        int result = Program.FuncMethodResult();

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void TestIsDecimalNumberFuncWithLinq()
    {
        // Arrange
        int[] expectedResult = { 11, 15 };
        List<int> actualDecimalNumbers = new List<int>();

        // Act
        IEnumerable<int> numbersArray = ActionAndFuncWithLambda.GetDecimalNumbers();

        foreach (int number in numbersArray)
        {
            actualDecimalNumbers.Add(number);

        }

        // Assert
        Assert.AreEqual(expectedResult.Length, actualDecimalNumbers.Count);
        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i], actualDecimalNumbers[i]);
        }

    }

    [TestMethod]
    public void TestMyActionWithoutArguments()
    {
        // Arrange
        Action action1 = Program.MyVoidMethod;
        var output = new StringBuilder();
        var stringwriter = new StringWriter(output);
        Console.SetOut(stringwriter);

        // Act
        action1();

        // Assert
        Assert.AreEqual("This is my first Action\r\n", output.ToString());

    }

    [TestMethod]
    public void TestMyFirstActionWithLambda()
    {
        // Arrange
        Action action2 = ActionAndFuncWithLambda.action2;
        var output = new StringBuilder();
        var stringwriter = new StringWriter(output);
        Console.SetOut(stringwriter);

        // Act
        action2();

        // Assert
        Assert.AreEqual("This is my first Action with Lambda\r\n", output.ToString());
    }

    [TestMethod]
    public void TestMyActionWithArguments()
    {
        // Arrange
        Action<string> action3 = Program.MyVoidMethodWithArgument;
        string arg1 = "Code-Maze";
        var output = new StringBuilder();
        var stringwriter = new StringWriter(output);
        Console.SetOut(stringwriter);

        // Act
        action3(arg1);

        // Assert
        Assert.AreEqual($"This is an Action with {arg1} as string parameter\r\n", output.ToString());
    }
}