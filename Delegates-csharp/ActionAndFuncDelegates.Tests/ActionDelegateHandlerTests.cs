
using Action_and_Func_Delegates_in_C_;
using Xunit;

public class ActionDelegateHandlerTests
{
    [Fact]
    public void LogToConsole_ShouldWriteToConsole()
    {
       
        var consoleOutput = new ConsoleOutput();
        
           
            ActionDelegateHandler.ActionDelegateExecution();

           
            Assert.Contains("Logging a message to the console.", consoleOutput.GetOutput());
        
    }
}
