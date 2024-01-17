using ActionFuncDelegateInCsharp;

Action actionDelegate = new Action(ActionDelegate.MethodToBeCalled);
actionDelegate();

Action<int, int> addNumbers = ActionDelegate.AddNumbers;
addNumbers(2, 5);

Action<string> displayMessage = ActionDelegate.DisplayMessage;
displayMessage("Hello, Action delegate!");

var result = FuncDelegate.AddNumbers(9, 7);

Console.WriteLine("The sum is: " + result); 