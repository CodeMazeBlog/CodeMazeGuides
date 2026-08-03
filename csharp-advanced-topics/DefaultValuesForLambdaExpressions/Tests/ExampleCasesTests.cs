namespace Tests;

public class ExampleCasesTests
{
    [Fact]
    public void GivenAnAnonymousFunction_WhenParameterIsNotProvided_ThenUsesTheDefaultParameter()
    {
        Assert.Equal("Hello, User!", ExampleCases.GreetUserWithDefaultValue());
    }

    [Fact]
    public void GivenAnAnonymousFunction_WhenParameterProvided_ThenUsesTheProvidedParameter()
    {
        Assert.Equal("Hello, Peter!", ExampleCases.GreetUserWithName());
    }

    [Fact]
    public void GivenAnAnonymousFunction_When3StringsProvided_ThenFormatsTheMessage()
    {
        Assert.Equal("Hello, team: John, Peter, Isaac.",
            ExampleCases.GreetTeamWith3Members());
    }

    [Fact]
    public void GivenAnAnonymousFunction_When5StringsProvided_ThenFormatsTheMessage()
    {
        Assert.Equal("Hello, team: John, Peter, Isaac, Theo, Matteo.",
            ExampleCases.GreetTeamWith5Members());
    }
}