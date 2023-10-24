namespace InterceptorsInCSharp.Tests;

public class Tests
{
    [Test]
    public void GivenICallTheRunMethod__ThenItShouldReturnTheValueFromTheInterceptingMethod()
    {
        //Arrange
        string expectedText = $"Hello, Code Maze!{Environment.NewLine}Greetings, Code Maze!\n";
        using var consoleTester = new ConsoleOutputTester();

        //Act
        Program.Main([]);
        var response = consoleTester.GetOutput();

        //Assert
        Assert.That(response, Is.EqualTo(expectedText));
    }
}