

Action actionSample = () =>
{
    Console.WriteLine("Hello Action");
};

ActionFuncSample.CallAnAction(actionSample);
ActionFuncSample.CallAnAction(() => Console.WriteLine("Hi"));

Func<bool> funcSample = () =>
{
    Console.WriteLine("Hello Func");
    return true;
};

ActionFuncSample.CallAFunc(funcSample);
ActionFuncSample.CallAFunc(() =>
{
    Console.WriteLine("Another func");
    Console.WriteLine("Press Y to return true");
    return Console.ReadKey().Key == ConsoleKey.Y;

});
