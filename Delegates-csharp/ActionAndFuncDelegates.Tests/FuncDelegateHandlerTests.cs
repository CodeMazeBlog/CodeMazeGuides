
using Action_and_Func_Delegates_in_C_;
using Xunit;

public class FuncDelegateHandlerTests
{
    [Fact]
    public void FuncDelegateExecution_ShouldReturnCorrectResult()
    {
       
        int result = FuncDelegateHandler.FuncDelegateExecution(5);

        
        Assert.Equal(25, result);
    }
}
