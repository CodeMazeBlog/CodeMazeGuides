using ActionAndFuncDelegatesInCSharp;
using Console = ActionAndFuncDelegatesInCSharp.Console;

FileReceiver fileReceiver = new();
FileHandler fileHandler =  new(fileReceiver, new Console());

fileHandler.Process("1", value => value % 2 == 0);
fileHandler.Process("2", value => value % 2 == 0);
fileReceiver.Start();
System.Console.ReadKey();