namespace Tests;

public class DelegatesUnitTest
{
    private delegate int Operate(int firstNumber, int secondNumber);

    [Fact]
    public void WhenTwoNumbersAreProvidedAsInput_ThenDelegateReturnsSumOfThem()
    {
        //Arrange
        int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        var firstNumber = 1;
        var secondNumber = 2;
        var expectedResult = 3;

        //Act
        var operate = new Operate(Add);
        var delegateExecutionResult = operate(firstNumber, secondNumber);

        //Assert
        Assert.Equal(expectedResult, delegateExecutionResult);

    }

    [Fact]
    public void WhenTwoNumbersAreProvidedAsInput_ThenDelegateReturnsProductOfThem()
    {
        //Arrange
        int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        var firstNumber = 1;
        var secondNumber = -2;
        var expectedResult = -2;

        //Act
        var operate = new Operate(Multiply);
        var delegateExecutionResult = operate(firstNumber, secondNumber);

        //Assert
        Assert.Equal(expectedResult, delegateExecutionResult);

    }

    [Fact]
    public void WhenTwoNumbersAreProvidedAsInput_ThenFuncDelegateReturnsSumOfThem()
    {
        //Arrange
        int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        var firstNumber = 1;
        var secondNumber = 2;
        var expectedResult = 3;

        //Act
        Func<int, int, int> operate = Add;
        var delegateExecutionResult = operate(firstNumber, secondNumber);

        //Assert
        Assert.Equal(expectedResult, delegateExecutionResult);

    }

    [Fact]
    public void WhenTwoNumbersAreProvidedAsInput_ThenFuncDelegateReturnsProductOfThem()
    {
        //Arrange
        int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        var firstNumber = 1;
        var secondNumber = -2;
        var expectedResult = -2;

        //Act
        Func<int, int, int> operate = Multiply;
        var delegateExecutionResult = operate(firstNumber, secondNumber);

        //Assert
        Assert.Equal(expectedResult, delegateExecutionResult);

    }

    [Fact]
    public void WhenActionDelegateIsExecuted_ThenVariableValueIsUpdated()
    {
        //Arrange
        string variableToBeUpdated = string.Empty;
        string updateMessage = "I am updated";

        void UpdateVariable(string message)
        {
            variableToBeUpdated = message;
        }

        Action<string> update = UpdateVariable;

        //Act
        update(updateMessage);

        //Assert
        Assert.Equal(updateMessage, variableToBeUpdated);

    }
}