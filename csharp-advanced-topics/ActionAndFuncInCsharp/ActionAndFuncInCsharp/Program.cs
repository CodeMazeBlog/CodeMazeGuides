//Func Delegate
Func<string, int> methodPointer= Count;
int num = methodPointer.Invoke("C Sharp");

Console.WriteLine(methodPointer("C sharp"));

int Count(string s)
{
    return s.Length;
}

//Action Delegate
Action<string> voidMethodPointer= PrintCount;
voidMethodPointer("Show me the numbers");

void PrintCount(string s)
{
    Console.WriteLine(s.Length);
}





