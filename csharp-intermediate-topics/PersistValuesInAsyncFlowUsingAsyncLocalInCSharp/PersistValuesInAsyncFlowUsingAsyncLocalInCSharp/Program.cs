using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

Console.WriteLine("AsyncLocalExample execution: ");
await AsyncLocalExample.DoWork();

Console.WriteLine();

Console.WriteLine("AsyncLocalVsThreadLocalExample execution: ");
await AsyncLocalVsThreadLocalExample.DoWork();

Console.WriteLine();

Console.WriteLine("AsyncLocalReferenceTypeExample execution: ");
await AsyncLocalReferenceTypeExample.DoWork();

Console.WriteLine();

Console.WriteLine("AsyncLocalNotifyExample execution: ");
await AsyncLocalNotifyExample.DoWork();
