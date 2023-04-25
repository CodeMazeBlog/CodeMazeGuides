// See https://aka.ms/new-console-template for more information

using ActionAndFuncDelegatesInCsharp;

Action<string> writeMessage = Display.DisplayText;
            writeMessage("Our world");

            Func<int, int, int> multiply = Calculator.Multiply;
            int myResult = multiply(1, 2);
            Console.WriteLine(myResult);
