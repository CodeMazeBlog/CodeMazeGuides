using System;

public class DoubleToStringTests
{
    public void TestDoublePositiveNumber()
    {
        int input = 5;
        string expectedOutput = "The double is: 10";

        Func<int, string> doubleToString = x => $"The double is: {x * 2}";
        string result = doubleToString(input);

        Assert.AreEqual(expectedOutput, result);
    }

    public void TestDoubleNegativeNumber()
    {
        int input = -3;
        string expectedOutput = "The double is: -6";

        Func<int, string> doubleToString = x => $"The double is: {x * 2}";
        string result = doubleToString(input);

        Assert.AreEqual(expectedOutput, result);
    }

    public void TestDoubleZero()
    {
        int input = 0;
        string expectedOutput = "The double is: 0";
        Func<int, string> doubleToString = x => $"The double is: {x * 2}";
        string result = doubleToString(input);

        Assert.AreEqual(expectedOutput, result);
    }
}


public class DataTransformationTests
{
    public void TestDoubleAllElements()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        List<string> expectedDoubles = new List<string> { "2", "4", "6", "8", "10" };

        List<string> doubledNumbers = numbers.Select(x => x * 2).ToList();

        CollectionAssert.AreEqual(expectedDoubles, doubledNumbers);
    }
}

public class FunctionCompositionTests
{
    public void TestSquareAndFormat()
    {
        int input = 5;
        string expectedOutput = "The square is: 25";

        Func<int, int> square = x => x * x;
        Func<int, string> squareAndFormat = square.Compose(x => $"The square is: {x}");
        string formattedSquare = squareAndFormat(input);

        Assert.AreEqual(expectedOutput, formattedSquare);
    }
}


