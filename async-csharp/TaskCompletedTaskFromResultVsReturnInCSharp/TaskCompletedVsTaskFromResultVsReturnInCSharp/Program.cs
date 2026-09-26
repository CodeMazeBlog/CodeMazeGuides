using TaskCompletedVsTaskFromResultVsReturnInCSharp;

var taskCompletedClass = new TaskCompletedHandler();
await taskCompletedClass.UseTaskCompletedAsync();

var taskFromResultClass = new TaskFromResultHandler();
await taskFromResultClass.UseTaskFromResultAsync();

var returnClass = new ReturnHandler();
await returnClass.UseReturnAsync();

Console.ReadKey();