using TaskCompletedVsReturnInCSharp;

var taskCompletedClass = new TaskCompletedClass();
await taskCompletedClass.UseTaskCompletedMethodAsync();

var returnClass = new ReturnClass();
await returnClass.UseReturnMethodAsync();

Console.ReadKey();