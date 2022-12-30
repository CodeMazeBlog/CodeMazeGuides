
using ActionAndFuncDelegatesInCSharp.Common;
using System;
Action<string> actionDelegate = new Action<string>(DisplayText);
actionDelegate("Hello World!");

var myDelegate = new MyDelegate(DisplayText);
myDelegate("Hello World!");

Console.WriteLine(DelegateHelper.GetTax(100000));
void DisplayText(string str)
{
    Console.WriteLine(str);
}

Console.Read();

delegate void MyDelegate(string str);