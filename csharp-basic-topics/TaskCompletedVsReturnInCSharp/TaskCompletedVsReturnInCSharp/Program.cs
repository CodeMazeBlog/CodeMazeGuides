using TaskCompletedVsReturnInCSharp;

TaskCompletedClass taskCompletedClass = new TaskCompletedClass();
await taskCompletedClass.UseTaskCompletedMethodAsync();

ReturnClass returnClass = new ReturnClass();
await returnClass.UseReturnMethodAsync();

Console.ReadKey();