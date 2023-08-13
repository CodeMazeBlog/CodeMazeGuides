using FuncActionDelegateSample;

namespace FuncAndActionTest;

public class FuncActionUnitTest
{
    [Fact]
    public void WhenFuncDelegatePassToSubtract_ThenReturnRightResult()
    {
        //arrange
        FuncActionDelegate funcActionDelegate = new FuncActionDelegate();

        //declare Func delegate
        Func<int, int, int> Operation = funcActionDelegate.Subtract;

        //act
         var value = Operation(10,5);

        //assert
        Assert.Equal(5, Convert.ToInt32(value));


    }

    [Fact]
    public void WhenActionDelegatePassToPrintFullname_ThenWriteRightResulToConsole()
    {
        //arrange
        var stringWriter = new StringWriter();

        Console.SetOut(stringWriter);

        FuncActionDelegate funcActionDelegate = new FuncActionDelegate();

        //declare Func delegate
        Action<string, string> Print = funcActionDelegate.PrintFullname;

        //act
        Print("Code", "Maze");
        
        //assert
        Assert.Equal("Code Maze", stringWriter.ToString());

    }
}
