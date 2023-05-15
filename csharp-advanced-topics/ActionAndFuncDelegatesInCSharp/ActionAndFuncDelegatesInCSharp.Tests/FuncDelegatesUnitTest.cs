namespace ActionAndFuncDelegatesInCSharp.Tests;

public class FuncDelegatesUnitTest
{
    [Fact]
    public void WhenGreetWithName_ThenReturnGreetingWithName()
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

