using System.IO;
using System.Text;
using System;

namespace Tests;

public class Tests
{
    // Define an instance of the action delegate
    private Action<int, int> printSumOfSquares;

    // Define an instance of the func delegate
    private Func<string, string> TakeActionAndCountCharacters;

    // Define a setup method that runs before each test
    [SetUp]
    public void Setup()
    {
        // Assign the action delegate to a lambda expression
        printSumOfSquares = (a, b) => Console.WriteLine((a * a) + (b * b));

        // Assign the func delegate to a method
        TakeActionAndCountCharacters = characterCount;
    }

    // Define a test method that checks the output of the action delegate
    [Test]
    public void WhenPrintSumOfSquares_ThenPrintCorrectOutput()
    {
        // Arrange
        // Create a string builder to capture the console output
        var sb = new StringBuilder();
        // Redirect the console output to the string builder
        Console.SetOut(new StringWriter(sb));

        // Act
        // Invoke the action delegate with some values
        printSumOfSquares(3, 3);

        // Assert
        // Check that the output matches the expected result
        Assert.That(sb.ToString(), Is.EqualTo("18\r\n"));
    }

    // Define a test method that checks the behavior of the TakeActionAndPrintSumOfSquares method
    [Test]
    public void WhenTakeActionAndPrintSumOfSquares_ThenInvokeAction()
    {
        // Arrange
        // Create a string builder to capture the console output
        var sb = new StringBuilder();
        // Redirect the console output to the string builder
        Console.SetOut(new StringWriter(sb));

        // Act
        // Call the TakeActionAndPrintSumOfSquares method with the action delegate as a parameter
        TakeActionAndPrintSumOfSquares(printSumOfSquares);

        // Assert
        // Check that the output matches the expected result
        Assert.That(sb.ToString(), Is.EqualTo("245\r\n"));
    }

    // Define a test method that checks the output of the func delegate
    [Test]
    public void WhenTakeActionAndCountCharacters_ThenReturnCorrectOutput()
    {
        // Arrange
        // Nothing to arrange

        // Act
        // Invoke the func delegate with some values and store the results
        var result = TakeActionAndCountCharacters("Hello");

        // Assert
        // Check that the result matches the expected output
        Assert.That(result, Is.EqualTo("There are 5 characters in the word Hello"));
    }

    // Define a helper method that takes an action delegate as a parameter and invokes it with different values
    private void TakeActionAndPrintSumOfSquares(Action<int, int> action)
    {
        action(7, 14);
    }

    // Define a helper method that returns the number of characters in a string
    private string characterCount(string word)
    {
        int count = word.Length;
        return $"There are {count} characters in the word {word}";
    }
}