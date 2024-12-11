using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

Console.WriteLine("AsyncLocalExample execution: ");
await AsyncLocalExample.DoWork();

Console.WriteLine();

Console.WriteLine("AsyncLocalNotifyExample execution: ");
await AsyncLocalNotifyExample.DoWork();
