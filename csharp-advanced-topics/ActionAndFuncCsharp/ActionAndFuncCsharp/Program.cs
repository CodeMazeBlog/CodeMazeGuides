using ActionAndFuncCsharp;

var actionDelegate = new ActionDelegate();

var displayText = new Action(actionDelegate.DisplayText);
var displayMsg = new Action<string>(actionDelegate.DisplayMessage);
var displayNumbers = new Action<int, int>(actionDelegate.DisplayNumbers);

Console.WriteLine("***Action<T> Delegate Methods ***");
displayText();    //Parameter: 0 , Returns: nothing
displayMsg("Hassan Iftikhar");  //Parameter: 1 , Returns: nothing
displayNumbers(10, 20); //Parameter: 2 , Returns: nothing
Console.WriteLine();

Console.WriteLine("*** Func<> Delegate Methods ***");

var funcDelegate = new FuncDelegate();
var power = new Func<int, int, int>(funcDelegate.TakePower);
var sum = new Func<int, int, string>(funcDelegate.DisplaySum);
var stringConcat = new Func<string, string, string>(funcDelegate.StringAppend);

var pow = power(2, 5);  //Parameter: 2 , Returns: int
var addition = sum(2,3);  //Parameter: 2 , Returns: string
var appendText = stringConcat("Hassan", "Iftikhar");    //Parameter:2 , Returns: string

Console.WriteLine($"Func<int, int, int> - Power of 2 is: {pow}");
Console.WriteLine($"Func<int, int, string> - {addition}");
Console.WriteLine($"Func<string, string, string> - String Concatenation of two strings: {appendText}");

Console.ReadLine();

