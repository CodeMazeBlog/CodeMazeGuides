namespace InterceptorsInCSharp.Tests;

public class Tests
{
    [Test]
    public void GivenIInterceptTheGetTextMethod_WhenIRunTheProgramMainMethod_ThenItShouldReturnTheValueFromTheInterceptingMethod()
    {
        //Arrange
        string expectedText = $"Hello, Code Maze!{Environment.NewLine}Greetings, Code Maze!{Environment.NewLine}";
        using var consoleTester = new ConsoleOutputTester();

        //Act
        Program.Main([]);
        var response = consoleTester.GetOutput();

        //Assert
        Assert.That(response, Is.EqualTo(expectedText));
    }
}