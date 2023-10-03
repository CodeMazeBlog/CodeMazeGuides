using ActionAndFuncDelegatesInCSharp;

var operations = new ArithmeticOperations();
var loggers = new Loggers();

// assigning a function to a Func delegate object
Func<double, double, double> func;

func = operations.Sum;
Console.WriteLine(func(5, 10));

func = operations.Multiply;
Console.WriteLine(func(5, 10));


// assigning a function to an Action delegate object
Action<string> log;

log = loggers.LogMessage;
log("Operation completed.");

log = loggers.LogMessageWithTimeStamp;
log("Operation completed.");



// using Func with lambda expressions
func = (a, b) => Math.Pow(a, b);
Console.WriteLine(func(3, 2));

// using Func as parameter of a function
double result = operations.ExecArithmeticOperation(operations.Multiply, 2, 3);
Console.WriteLine(result);

// using Func in collections
List<Func<double, double, double>> functions = new()
{
    operations.Sum,
    operations.Multiply,
    (a, b) => Math.Pow(a, b),
};

double a = 3;
double b = 2;
double res = 0;
foreach (Func<double, double, double> f in functions)
{
    res += f(a, b);
}
Console.WriteLine(res);

