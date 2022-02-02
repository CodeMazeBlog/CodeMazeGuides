using FuncAndAction;
using static FuncAndAction.FuncAndActionService;

FuncAndActionService _service = new FuncAndActionService();
DelegateMethod d1 = new DelegateMethod(_service.DisplayResult);
var result = d1(3, 5);
Console.WriteLine(result);

var func = new Func<int, int, int>(_service.CalculateValue);
Console.WriteLine(func(2, 5));

var action = new Action<int>(_service.PrintValue);
// it prints the "123" value on the screen
action(123);

// Also we can use this calling format
action.Invoke(123);

