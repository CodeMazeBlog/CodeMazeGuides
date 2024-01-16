// See https://aka.ms/new-console-template for more information
// Creating an Action delegate and assigning the method from another class
using ActionFuncDelegateInCsharp;

Action actionDelegate = new Action(ActionDelegate.MethodToBeCalled);
actionDelegate();

// Using Action delegate with a method from another class
Action<int, int> addNumbers = ActionDelegate.AddNumbers;
addNumbers(2, 5);

// Using Action delegate with a method from another class
Action<string> displayMessage = ActionDelegate.DisplayMessage;
displayMessage("Hello, Action delegate!");

// Using the Func<> delegate to find the sum of two numbers
int result = FuncDelegate.AddNumbers(9, 7);

Console.WriteLine("The sum is: " + result); 