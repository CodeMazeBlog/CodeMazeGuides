using TaskCompletedVsReturnInCSharp;

var taskCompletedClass = new TaskCompletedClass();
await taskCompletedClass.UseTaskCompletedMethodAsync();

var taskFromResultClass = new TaskFromResultClass();
await taskFromResultClass.UseTaskFromResultMethodAsync();

var returnClass = new ReturnClass();
await returnClass.UseReturnMethodAsync();

Console.ReadKey();