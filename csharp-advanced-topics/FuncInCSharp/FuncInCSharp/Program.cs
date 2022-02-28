string resultMessage;

Func<int, int, string> MutipleFuncMethod = MultipleFuncNumbers;
resultMessage = MutipleFuncMethod(5, 3);
Console.WriteLine($"Func without lambda = {resultMessage}");

Func<int, int, string> MutipleFuncLambdaMethod = (a, b) => MultipleFuncNumbers(a, b);
resultMessage = MutipleFuncLambdaMethod(5, 3);
Console.WriteLine($"Func with lambda = {resultMessage}");

string MultipleFuncNumbers(int a, int b)
{
    return "Mutiplied number : " + a * b;
}
