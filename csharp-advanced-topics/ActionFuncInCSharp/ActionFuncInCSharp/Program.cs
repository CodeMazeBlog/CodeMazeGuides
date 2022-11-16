using ActionFuncInCSharp;

var basicCalculator = new BasicCalculator();

#region Func examples

Func<float, float, float> calcFunc = basicCalculator.Addition;
Console.WriteLine(calcFunc(3, 2));

// Func as method return type
var func = basicCalculator.GetCalcFunc(BasicCalculationEnum.Addition);
int calcResult = func(5, 4);

// Func as parameter
List<string> progLang = new() { "C", "C++", "C#", "F#", "Rust", "Go" };
Func<string, bool> whereFunc = (string s) => { return s.Contains('C'); };
List<string> cLang = progLang.Where(whereFunc).ToList();

#endregion

#region multicast delegate
BasicCalcDelegate basicCalcPrint = basicCalculator.AdditionPrint;
basicCalcPrint += basicCalculator.SubtractionPrint;
basicCalcPrint += basicCalculator.MultiplicationPrint;
basicCalcPrint += basicCalculator.DivisionPrint;

basicCalcPrint(2, 2); 
#endregion

#region generic multicast delegate <int>
BasicCalcDelegate<int> basicCalcPrintGeneric = basicCalculator.AdditionPrint;
basicCalcPrintGeneric += basicCalculator.SubtractionPrint;
basicCalcPrintGeneric += basicCalculator.MultiplicationPrint;
basicCalcPrintGeneric += basicCalculator.DivisionPrint;

basicCalcPrintGeneric(3, 2); 
#endregion

#region  parameterless action and  parameterized action
Action SayHello = () => Console.WriteLine("Hello...");

Action<string> sayHelloAction = (string name) => Console.WriteLine("Hello {0}", name);

sayHelloAction("Ahmad");

#endregion

#region mulricast Action and invocation list
Action<int, int> calcPrintAction = basicCalculator.AdditionPrint;
calcPrintAction += basicCalculator.SubtractionPrint;
calcPrintAction += basicCalculator.MultiplicationPrint;
calcPrintAction += basicCalculator.DivisionPrint;

calcPrintAction(4, 2);

Delegate[] delegates = calcPrintAction.GetInvocationList();
foreach (var del in delegates)
{
    Console.WriteLine(del.Method.Name);
}

Console.WriteLine("Number of calls: " + calcPrintAction.GetInvocationList().Length);

#endregion

#region Contravariance example

Action<Child> action = printTypeName;
void printTypeName(Parent parent)
{
    Console.WriteLine(parent.Name);
}

action(new Child()); 
#endregion
 
#region callback Action example
void printInt(int number)
{
    Console.WriteLine("the number is {0}", number);
}

void CalculateAndPrint(int number1, int number2, Action<int> printAction)
{
    int summation = number1 + number2;
    printAction(summation);
}

CalculateAndPrint(5, 5, printInt); 
#endregion


