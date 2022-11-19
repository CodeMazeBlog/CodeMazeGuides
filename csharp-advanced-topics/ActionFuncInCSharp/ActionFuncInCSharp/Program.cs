using ActionFuncInCSharp;

var intBasicCalculator = new IntBasicCalculator();

Action<int, int> calcPrintAction = intBasicCalculator.AdditionPrint;
calcPrintAction += intBasicCalculator.SubtractionPrint;
calcPrintAction += intBasicCalculator.MultiplicationPrint;
calcPrintAction += intBasicCalculator.DivisionPrint;

calcPrintAction(4, 2);

Delegate[] delegates = calcPrintAction.GetInvocationList();
foreach (var del in delegates)
{
    Console.WriteLine(del.Method.Name);
}

Console.WriteLine("Number of calls: " + calcPrintAction.GetInvocationList().Length);