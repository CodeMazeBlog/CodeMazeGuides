using ActionAndFuncDelegatesInCSharp;
namespace ActionAndFuncDelegatesInCSharp.Tests;
public class FuncDelegatesTest : IDisposable
{
    private readonly StringWriter _stringWriter;
    public FuncDelegatesTest()
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
        Func<string, string, string> greetWithName = FuncDelegates.GreetWithName;
        string firstName = "Ralph";
        string lastName = "Nyoni";

        // Act
        string result = greetWithName(firstName, lastName);

        // Assert
        string expectedResult = $"Hello: {firstName + ' ' + lastName}";
        Assert.Equal(expectedResult, result);
    }
}

