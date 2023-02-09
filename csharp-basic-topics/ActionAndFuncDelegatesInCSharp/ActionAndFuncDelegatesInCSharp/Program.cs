using ActionAndFuncDelegatesInCSharp;

FileReceiver fileReceiver = new();
FileHandler fileHandler =  new(fileReceiver);

fileHandler.Process("1", value => value % 2 == 0);
fileHandler.Process("2", value => value % 2 == 0);
fileReceiver.Start();
Console.ReadKey();