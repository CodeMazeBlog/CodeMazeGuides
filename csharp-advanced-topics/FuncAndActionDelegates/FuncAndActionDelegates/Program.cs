

using FuncAndActionDelegates;

static void PerformActions()
{
     FuncSample funcSample = new FuncSample();
     FuncAsParam sample = new FuncAsParam();


    Action<int> firstAction = ActionWithOneParameter;
    Action<int, int> secondAction = ActionWithTwoParameters;
    Action<int, int, int> thirdAction = ActionWithThreeParameters;

    firstAction(1); // Print 1
    secondAction(1, 2); // Print 1-2
    thirdAction(1, 2, 3); //Print 1-2-3


    //Action with Lambda Expression

    Action actionWithoutParams = () =>
    {
        Console.WriteLine("Action with Lambda expression without parameters");
    };

    Action<int> actionWithOneParameter = (arg1) =>
    {
        Console.WriteLine("Action with Lambda expression with one parameters: " + arg1);
    };

    Action<int, int> actionWithTwoParameter = (arg1, arg2) =>
    {
        Console.WriteLine("Action with Lambda expression with two parameters:{0},{1}", arg1, arg2);
    };

    actionWithoutParams();
    actionWithOneParameter(1);
    actionWithTwoParameter(1, 2);

}


PerformActions();


static void ActionWithOneParameter(int arg)
{
    Console.WriteLine(arg);
}

static void ActionWithTwoParameters(int arg1, int arg2)
{
    Console.WriteLine(arg1 + "-" + arg2);
}

static void ActionWithThreeParameters(int arg1, int arg2, int arg3)
{
    Console.WriteLine(arg1 + "-" + arg2 + "-" + arg3);
}
