using ActionAndFuncDelegatesInCSharp;
namespace ActionAndFuncDelegatesInCSharp.Tests;
public class FuncDelegatesUnitTest : IDisposable
{
    private readonly StringWriter _stringWriter;
    public FuncDelegatesUnitTest()
    {
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }
    public void Dispose()
    {
        _stringWriter.Dispose();
    }

    [Fact]
    public void When_GreetWithName_Then_ReturnGreetingWithName()
    {
        // Arrange
        Func<string, string, string> greetWithNameTest = FuncDelegates.GreetWithName;
        string firstName = "Ralph";
        string lastName = "Nyoni";

        // Act
        string result = greetWithNameTest(firstName, lastName);

        // Assert
        string expectedResult = $"Hello: {firstName + ' ' + lastName}";
        Assert.Equal(expectedResult, result);
    } 
}

