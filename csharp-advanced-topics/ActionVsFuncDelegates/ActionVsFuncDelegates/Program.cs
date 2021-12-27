
using ActionVsFuncDelegates;

Console.WriteLine("\n\n=========Action=========");
var mathAction = new MathAction();
mathAction.ShowAll();


Console.WriteLine("\n\n=========Func=========");
var mathFunc = new MathFunc();
mathFunc.ShowAll();