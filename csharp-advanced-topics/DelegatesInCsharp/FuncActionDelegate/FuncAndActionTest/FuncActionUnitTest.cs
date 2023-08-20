using FuncActionDelegateSample;

namespace FuncAndActionTest;

public class FuncActionUnitTest
{
    FuncActionDelegate funcActionDelegate = new FuncActionDelegate();

    [Fact]
    public void WhenFuncDelegatePassToSubtract_ThenReturnRightResult()
    {
        Func<int, int, int> Operation = funcActionDelegate.Subtract;

         var value = Operation(10,5);

        Assert.Equal(5, Convert.ToInt32(value));
    }

    [Fact]
    public void WhenActionDelegatePassToPrintFullname_ThenWriteRightResulToConsole()
    {
        var stringWriter = new StringWriter();

        Console.SetOut(stringWriter);

        Action<string, string> Print = funcActionDelegate.PrintFullName;

        Print("Code", "Maze");
        
        Assert.Equal("Code Maze", stringWriter.ToString());

    }
}
