using Xunit;
using static ActionAndFuncInCSharp.MethodsDefinitions;

namespace ActionAndFuncInCSharpTests;

public class ProgramUnitTest
{
    [Fact]
    public void GivenDelegateDefined_WhenInvoke_ThenGetExpectedResult()
    {
        AggregateStrings handler = GetFullName;
        var result = GreetingsWithDelegate("John", "Doe", handler);
        
        Assert.Equal("Hello from John Doe", result);
    }

    [Fact]
    public void GivenActionDefined_WhenInvoke_ThenGetExpectedResult()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
        
        Action<string, string> act = Greeting;
        act("John", "Doe");
        
        const string expectedOutput = "Hello from John Doe!";
        Assert.Equal(expectedOutput, sw.ToString().Trim());
    }
    
    [Fact]
    public void GivenFuncDefined_WhenInvoke_ThenGetExpectedResult()
    {
        Func<int, int, long> func = Area;
        var area = func(3, 5);
        
        Assert.Equal(15, area);
    }
}