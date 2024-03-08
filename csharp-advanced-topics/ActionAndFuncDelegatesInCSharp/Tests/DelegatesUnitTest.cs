using ActionAndDelegatesInCSharp;
namespace Tests;
public class DelegatesUnitTest
{   
    [Fact]
    public void WhenTwoNumbersAreProvidedAsInput_ThenDelegateReturnsSumOfThem()
    {
        //Arrange
        var firstNumber = 1;
        var secondNumber = 2;
        var expectedResult = 3;

        //Act
        var operate = new Program.OperateDelegate(Program.Add);
        var delegateExecutionResult = operate(firstNumber, secondNumber);

        //Assert
        Assert.Equal(expectedResult, delegateExecutionResult);
    }

    [Fact]
    public void WhenTwoNumbersAreProvidedAsInput_ThenFuncDelegateReturnsSumOfThem()
    {
        //Arrange
        var firstNumber = 1;
        var secondNumber = 2;
        var expectedResult = 3;

        //Act
        Program.Operate = Program.Add;
        var delegateExecutionResult = Program.Operate(firstNumber, secondNumber);

        //Assert
        Assert.Equal(expectedResult, delegateExecutionResult);
    }

    [Fact]
    public void WhenActionDelegateIsExecuted_ThenMessageIsLoggedOnConsole()
    {
        //Arrange
        var expectedOutput = "The result of delegate operation is 1.\r\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //Act
        Program.Display = Program.DisplayOnConsole;
        Program.Display(1);

        //Assert
        Assert.Equal(expectedOutput, stringWriter.ToString());
    }

    [Fact]
    public void WhenMainFunctionIsExecuted_ThenMessageIsLoggedOnConsole()
    { 
        //Arrange
        var expectedFirstOutput = "The result of operatedelegate operation is 3.";
        var expectedSecondOutput = "The result of delegate operation is 3.";
        var expectedOutputCounts = 2;

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        //Act
        Program.Main(Array.Empty<string>());

        //Assert
        var appendedOutput = stringWriter.ToString();
        var splitConsoleOutputs = appendedOutput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal(expectedOutputCounts, splitConsoleOutputs.Count());
        Assert.Equal(expectedFirstOutput, splitConsoleOutputs[0]);
        Assert.Equal(expectedSecondOutput, splitConsoleOutputs[1]);        
    }
}