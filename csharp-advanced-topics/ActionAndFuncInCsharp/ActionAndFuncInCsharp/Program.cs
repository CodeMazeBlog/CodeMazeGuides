using ActionAndFuncInCsharp;

//Func Delegate
Func<string, int> methodPointer = CountMethods.Count;
int num = methodPointer.Invoke("C Sharp");
Console.WriteLine(methodPointer("C sharp"));

//Action Delegate
Action<string> voidMethodPointer = CountMethods.PrintCount;
voidMethodPointer("Show me the numbers");