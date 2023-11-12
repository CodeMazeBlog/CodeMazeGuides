
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
    func.PerformFiltration(numbers);
}
else if (input == "Action")
{
    //Assign method reference to an Action<string> delegate.Log information level messages.
    Action<string> infoLogger = (message) 
        => Console.WriteLine($"Additional information: {message}");
    
    ActionDelegate.Information(infoLogger, "The request was intercepted by filtering middleware.");

    //Direct reference to a method. Log error level messages.
    Action<string> errorLogger = ActionDelegate.Error;
    errorLogger("Invalid request error");

    // Pass an anonymous delegate of type Action using a lambda expression.Log warning level messages.
    ActionDelegate.Warning(() 
        => Console.WriteLine($"The operation succeeded with a warning: The request was intercepted by filtering middleware"));
}
else
{
    Console.WriteLine("Choose again!");
}

