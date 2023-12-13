
using Action_and_Func_Delegates_in_C_;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void Main_ShouldRunActionAndFuncHandlers()
    {
        
        using (var consoleOutput = new ConsoleOutput())
        {
            
            Program.Main(null);

            
            Assert.Contains("Logging a message to the console.", consoleOutput.GetOutput());
            Assert.Contains("The result of FuncDelegate is: 25", consoleOutput.GetOutput());
        }
    }
}
