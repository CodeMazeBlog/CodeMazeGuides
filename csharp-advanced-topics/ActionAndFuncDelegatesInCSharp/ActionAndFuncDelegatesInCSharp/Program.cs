#region Explicit declaration of Func and Action variables

// Declares a Func variable that accepts a double value and returns a double value
Func<double, double> findRoot;

// declares an Action variable that accepts a string
Action<string> logMessage;

// Declares a Func variable that takes 2 int parameters and returns an int value
Func<int, int, int> findSum;

#endregion

#region Initializing Action and Func variables

// Point to a named method
findRoot = Math.Sqrt;

// Point to an anonymous method
logMessage = delegate(string message)
{
    Console.WriteLine(message);
};

// Point to a lambda expression
// Note that the parameter and return types of the lambda expression is automatically inferred
findSum = (x, y) => x + y;

#endregion

#region Invoking Action and Func

// call like a normal method
findRoot(25);

// use .Invoke()
findSum.Invoke(5, 10);

// use .Invoke() together with the null conditional operator to avoid possible NullReferenceException
findSum = null;
findSum?.Invoke(5, 10);

#endregion

#region Refactored to use Func 

static void PlotGraph(Func<int, int> func)
{
    for (var i = 0; i < 10; i++)
    {
        Console.WriteLine($"(x = {i}, y = {func(i)})");
    }
}

PlotGraph(x => 2 * x + 3);
/*
 * Output
 *
 * (x = 0, y = 3)
 * (x = 1, y = 5)
 * (x = 2, y = 7)
 * (x = 3, y = 9)
 * (x = 4, y = 11)
 * (x = 5, y = 13)
 * (x = 6, y = 15)
 * (x = 7, y = 17)
 * (x = 8, y = 19)
 * (x = 9, y = 21)
 */
 
#endregion

#region Multicast delegates using Func/Action

Action<string> logConsole = Console.WriteLine;
Action<string> logDb = msg => Console.WriteLine($"log to db. msg: {msg}");
Action<string> logApi = msg => Console.WriteLine($"log to API. msg: {msg}");

Action<string> log = logConsole + logDb + logApi;

log("hello");

/*
 * Output
 *
 * hello
 * log to db. msg: hello
 * log to API. msg: hello
 */

#endregion

#region Getting the return value of each Func delegate from a multicast delegate

Func<string, string> toUpper = str => str.ToUpper();
Func<string, string> toLower = str => str.ToLower();
Func<string, string> transform = toUpper + toLower;

foreach (var @delegate in transform.GetInvocationList())
{
    var func = (Func<string, string>)@delegate;
    Console.WriteLine(func("HEllO"));
}

/*
 * Output
 *
 * hello
 * HELLO
 */

#endregion

// please also check ../Tests/ActionUnitTest.cs and ../Tests/FuncUnitTest.cs