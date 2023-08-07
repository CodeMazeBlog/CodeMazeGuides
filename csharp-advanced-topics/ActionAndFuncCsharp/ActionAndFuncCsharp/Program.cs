using ActionAndFuncCsharp;

var actionDelegate = new ActionDelegate();

Action displayText = actionDelegate.DisplayText;
Action<string> displayMsg = actionDelegate.DisplayMessage;
Action<int,int> displayNumbers = actionDelegate.DisplaySum;

Console.WriteLine("***Action<T> Delegate Methods ***");
displayText();    //Parameter: 0 , Returns: nothing
displayMsg("Hassan Iftikhar");  //Parameter: 1 , Returns: nothing
displayNumbers(10, 20); //Parameter: 2 , Returns: nothing
Console.WriteLine();

Console.WriteLine("*** Func<> Delegate Methods ***");

var funcDelegate = new FuncDelegate();

Func<int,int,int> power = funcDelegate.TakePower;
Func<int, int, string> sum = funcDelegate.DisplaySum;
Func<string,string,string> stringConcat = funcDelegate.StringAppend;

var pow = power(2, 5);  //Parameter: 2 , Returns: int
var addition = sum(2,3);  //Parameter: 2 , Returns: string
var appendText = stringConcat("Hassan", "Iftikhar");    //Parameter:2 , Returns: string

Console.WriteLine($"Func<int, int, int> - Power of 2 is: {pow}");
Console.WriteLine($"Func<int, int, string> - {addition}");
Console.WriteLine($"Func<string, string, string> - String Concatenation of two strings: {appendText}");

Console.ReadLine();

