const string TEXT = "programming delegates in csharp";
var myDelegate = new MyDelegate(ConvertToLower);
var textInLowerCase = myDelegate("PROGRAMMING DELEGATES IN CSHARP");
Console.WriteLine(textInLowerCase);

Action<string> actionDelegate = new Action<string>(Display);
actionDelegate("Hello World!");
void Display(string str) => Console.WriteLine(str);

string ConvertToLower(string str) => str.ToLower();

Func<double, double> func = new Func<double, double>(GetHra);
Console.WriteLine(func(1000.00));
Console.Read();

static double GetHra(double basic) => (double)(basic * .4);

internal delegate string MyDelegate(string str);