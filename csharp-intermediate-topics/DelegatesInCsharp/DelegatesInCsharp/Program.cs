using DelegatesInCsharp;

var textInLowerCase = DelegateExample.GetTextInLowercase(DelegateExample.TEXT_IN_UPPER_CASE);
Console.WriteLine(textInLowerCase);

Action<string> actionDelegate = new Action<string>(Display);
actionDelegate("Hello World!");
void Display(string str) => Console.WriteLine(str);

Console.WriteLine(DelegateExample.GetHra(1000.00));
Console.Read();