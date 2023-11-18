Console.WriteLine("Choose between delegate, Action or Func.");
var input = Console.ReadLine();

if (input == "delegate")
{
    var delegateIntroduction = new Delegate();
    delegateIntroduction.InvokeSimpleDelegate();
}
else if (input == "Func")
{
    var func = new FuncDelegate();
    var numbers = new List<int>
    {
        42,18,7,31,55,89,23,14,68,37,91,12,63,29,50,5,18,7,31,55,89,23,14,68,37,91,12,63,29,50,5,82
    };

    var filtered = func.PerformFiltration(numbers);

    Console.WriteLine("Even number: ");
    Console.WriteLine(string.Join(", ", filtered));
}
else if (input == "Action")
{
    Action<string> infoLogger = (message)
        => Console.WriteLine($"Additional information: {message}");

    var actionDelegate = new ActionDelegate();
    actionDelegate.Information(
        infoLogger,
        "The request was intercepted by filtering middleware.");

    Action<string> errorLogger = actionDelegate.Error;
    errorLogger("Invalid request error");

    actionDelegate.Warning(()
        => Console.WriteLine("The operation succeeded with a warning: " +
              "The request was intercepted by filtering middleware"));
}
else
{
    Console.WriteLine("Choose again!");
}

