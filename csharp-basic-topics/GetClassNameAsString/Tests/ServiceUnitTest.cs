namespace GetClassNameAsString.Tests;

[Collection("Sequential")]
public class ServiceUnitTest
{
    [Fact]
    public void WhenGreetingWithNullInput_ThrowsException()
    {
        Service service = new();
        var exception = Record.Exception(() => service.Greeting(""));
        Assert.IsType<ArgumentNullException>(exception);
        Assert.Equal("Value cannot be null. (Parameter 'name')", exception.Message);
    }

    [Fact]
    public void WhenGreetingWithName_ThenCorrectGreeting()
    {
        Service service = new();
        var greeting = service.Greeting("Code Maze");
        Assert.Equal("Hello Code Maze", greeting);
    }
}