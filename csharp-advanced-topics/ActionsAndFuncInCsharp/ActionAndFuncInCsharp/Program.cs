// See https://aka.ms/new-console-template for more information

using ActionAndFuncInCsharpConsole;

Console.WriteLine("Hello, World!");

var example = new DelegateExample(); 

example.PerformCalculate();
example.PerformCalculate(Multiple );
example.PerformCalculate(example.Difference);
var example2 = new ActionExamples();
example2.DoSomeWork();
example2.DoSomeWork2(); 

var example3 = new FuncExample();

example3.PerformCalculate('+', 3,4);
example3.PerformCalculate(3,5,Multiple);
int Multiple(int a, int b)
{
    return a * b;
}