using FuncDelegatesInCsharp;

namespace FuncDelegatesInCsharpTests;

public class ProgramTests
{
    [Fact]
    public void GivenTheAddMethodWithTwoArguments2And3_WhenExecuteCalled_ThenAddMethodInvokedAndExecuteReturns5()
    {
        // When
        var result = Program.Execute(() => Program.Add(2, 3));

        // Then
        Assert.Equal(5, result);
    }

    [Fact]
    public void GivenTheAddMethodWithParametersFromExecute_WhenExecuteCalled_ThenAddMethodInvokedWithParametersAsArgumentsReturns5()
    {
        // When
        var result = Program.Execute((arg1, arg2) => Program.Add(arg1, arg2));

        // Then
        Assert.Equal(5, result);
    }
}
