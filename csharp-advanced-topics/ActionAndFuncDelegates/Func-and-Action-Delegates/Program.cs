// See https://aka.ms/new-console-template for more information
using Func_and_Action_Delegates;

var calculator = new Calculator();

var calculatorWrapper = new CalculatorWrapper(calculator.Add);

Console.WriteLine("The sum of your numbers is {0}", calculatorWrapper.Add(6, 7));


Action<string> greetUser = message => Console.WriteLine($"{message}");

GreetUser greet = new GreetUser(greetUser);

greet.SayHi("Hi Dan!");





