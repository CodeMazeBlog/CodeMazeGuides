using ActionFuncInCSharp;

BasicCalculator basicCalculator = new BasicCalculator();

BasicCalcDelegate basicCalcPrint = basicCalculator.AdditionPrint;
basicCalcPrint += basicCalculator.SubtractionPrint;
basicCalcPrint += basicCalculator.MultiplicationPrint;
basicCalcPrint += basicCalculator.DivisionPrint;

basicCalcPrint(2, 2);

Console.WriteLine("=========================================");

BasicCalcDelegate<float> basicCalcPrintGeneric = basicCalculator.AdditionPrint;
basicCalcPrintGeneric += basicCalculator.SubtractionPrint;
basicCalcPrintGeneric += basicCalculator.MultiplicationPrint;
basicCalcPrintGeneric += basicCalculator.DivisionPrint;
basicCalcPrintGeneric(3, 2);

Console.WriteLine("=========================================");


Action<int, int> calcPrintAction = basicCalculator.AdditionPrint;
calcPrintAction += basicCalculator.SubtractionPrint;
calcPrintAction += basicCalculator.MultiplicationPrint;
calcPrintAction += basicCalculator.DivisionPrint;
calcPrintAction(4, 2);

Console.WriteLine("Number of calls: " + calcPrintAction.GetInvocationList().Length);

Console.WriteLine("=========================================");

Func<float,float,float> calcFunc = basicCalculator.Addition;
Console.WriteLine(calcFunc(3,2));


Console.WriteLine("=========================================");

GenericClass genericClass = new GenericClass();
int i = default; float f = default; string s= string.Empty;
genericClass.PrintTypeName(i);
genericClass.PrintTypeName(s);
genericClass.PrintTypeName(basicCalculator);