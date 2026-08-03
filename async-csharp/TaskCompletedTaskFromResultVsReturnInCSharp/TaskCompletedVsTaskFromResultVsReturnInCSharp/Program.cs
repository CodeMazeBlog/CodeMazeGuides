using TaskCompletedVsTaskFromResultVsReturnInCSharp;

var taskCompletedClass = new TaskCompletedHandler();
await taskCompletedClass.UseTaskCompletedAsync();
taskCompletedClass.UseTaskCompletedSync();

var taskFromResultClass = new TaskFromResultHandler();
await taskFromResultClass.UseTaskFromResultAsync();
taskFromResultClass.UseTaskFromResultSync();

var returnClass = new ReturnHandler();
await returnClass.UseReturnAsync();

Console.ReadKey();