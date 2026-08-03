using BenchmarkDotNet.Running;
using LocalFunctionsVsLambdaExpressionsInCSharp;

BenchmarkRunner.Run<LocalFunctionLambdaExpressionBenchmark>();

var factorialAsLocalFunction = Recursivity.FactorialAsLocalFunction(5);
var factorialAsLambdaExpression = Recursivity.FactorialAsLambdaExpression(5);

object first = 5;
object second = 10;
GenericLocalFunctions.SwapElements(ref first, ref second);

first = "a";
second = "b";
GenericLocalFunctions.SwapElements(ref first, ref second);

var numberList = new List<int> { 1, -1, 0, -2, 3, -5 };
IteratorLocalFunctions.IntegersToAbsoluteValue(numberList);
