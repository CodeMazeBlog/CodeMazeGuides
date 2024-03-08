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
        var expectedOutput = "The result of delegate operation is 1.";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //Act
        Program.Display = Program.DisplayOnConsole;
        Program.Display(1);

        //Assert
        var actualResult = stringWriter.ToString();
        Assert.Contains(expectedOutput, actualResult);
    }

    [Fact]
    public void WhenMainFunctionIsExecuted_ThenMessageIsLoggedOnConsole()
    { 
        //Arrange
        var expectedFirstOutput = "The result of operatedelegate operation is 3.";
        var expectedSecondOutput = "The result of delegate operation is 3.";
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        //Act
        Program.Main(Array.Empty<string>());

        //Assert
        var appendedOutput = stringWriter.ToString();
        Assert.Contains(expectedFirstOutput, appendedOutput);
        Assert.Contains(expectedSecondOutput, appendedOutput);
    }
}