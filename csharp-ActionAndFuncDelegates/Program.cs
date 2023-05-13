Action<string> printToConsole = (string s) => Console.WriteLine(s);
printToConsole("Hello, world");
Func<int, int, int> addNumbers = (int a, int b) => a + b; //Func Delegate definition
int sum = addNumbers(5, 10); //Using the delegate and saving its return value in a variable
Console.WriteLine($"The sum is {sum}");

