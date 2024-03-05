//Function to be referenced in Func
int Add(int firstNumber, int secondNumber)
{
    return firstNumber + secondNumber;
}

//Function to be referenced in Action
void DisplayOnConsole(int result)
{
    Console.WriteLine($"The result of delegate operation is {result}.");
}

var operateDelegate = new OperateDelegate(Add);

var delegateExecutionResult = operateDelegate(1, 2);

Console.WriteLine($"The result of operatedelegate operation is {delegateExecutionResult}.");

//Func declaration and instantiation
Func<int, int, int> operate = Add;

//Invocation
var result = operate(1, 2);

//Action declaration and instantiation
Action<int> display = DisplayOnConsole;

display(result);

Console.ReadKey();

delegate int OperateDelegate(int firstNumber, int secondNumber);