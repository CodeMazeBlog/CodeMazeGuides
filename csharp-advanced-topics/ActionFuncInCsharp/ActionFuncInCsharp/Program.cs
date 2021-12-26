
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
#endregion