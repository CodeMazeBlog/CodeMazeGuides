
#region Action

Action actionSample = () =>
{
    Console.WriteLine("Hello Action");
};

Action anotherActionSample = () =>
{
    Console.WriteLine("Hello");
    Thread.Sleep(1000);
    Console.WriteLine("Another");
    Thread.Sleep(1000);
    Console.WriteLine("Action");
    Thread.Sleep(1000);
};

ActionFuncSample.CallAnAction(actionSample);
ActionFuncSample.CallAnAction(anotherActionSample);
ActionFuncSample.CallAnActionWithParameters((int x, string s) =>
{
    Console.WriteLine($"The int value is {x} and the string is {s}");
});
#endregion

#region Func


Func<bool> funcSample = () =>
{
    Console.WriteLine("Hello Func");
    bool isPair = Random.Shared.Next() % 2 == 0;
    return isPair;
};

ActionFuncSample.CallAFunc(funcSample);
ActionFuncSample.CallAFunc(() => true);
ActionFuncSample.CallAFuncWithParameters((int x, string s) =>
{
    Console.WriteLine($"The int value is {x} and the string value is {s}. Do you agree? Yes or No?");
    return Console.ReadKey(true).Key == ConsoleKey.Y;
});
#endregion