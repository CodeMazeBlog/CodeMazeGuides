using MultipleTasksDemo.Client;
using MultipleTasksDemo.Client.Extensions;

Executor _executor = new(new EmployeeApiFacade());

var _id = new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e");
Guid[] _employeeIds =
[
    new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
    new Guid("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
    new Guid("165bcfa8-3a4f-4850-a681-bc496616f830")
];

// dotnet run -- <demo>, for example: dotnet run -- parallel
var demo = args.Length > 0 ? args[0] : "sequence";

try
{
    switch (demo)
    {
        case "sequence": (await _executor.ExecuteInSequence(_id)).Display(); break;
        case "parallel-when-all": (await _executor.ExecuteInParallelUsingTaskWhenAll(_id)).Display(); break;
        case "parallel": (await _executor.ExecuteInParallel(_id)).Display(); break;
        case "foreach": (await _executor.ExecuteUsingNormalForEach(_employeeIds)).Display(); break;
        case "parallel-foreach": _executor.ExecuteUsingParallelForeach(_employeeIds).Display(); break;
        case "parallel-foreach-async": (await _executor.ExecuteUsingParallelForeachAsync(_employeeIds)).Display(); break;
        case "when-all": (await _executor.ExecuteUsingTaskWhenAll(_employeeIds)).Display(); break;
        case "when-each": (await _executor.ExecuteUsingTaskWhenEach(_employeeIds)).Display(); break;
        default: Console.WriteLine($"Unknown demo: {demo}"); break;
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
