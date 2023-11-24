using MultipleTasksDemo.Client;
using MultipleTasksDemo.Client.Extensions;

Executor _executor = new(new EmployeeApiFacade());

var _id = new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e");
var _employeeIds = new[]
{
	new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
	new Guid("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
	new Guid("165bcfa8-3a4f-4850-a681-bc496616f830")
};

try
{
	await ExecuteInSequence();

	//await ExecuteInParallel();

	//await ExecuteUsingNormalForEach();

	//ExecuteUsingParallelForeach();

	//await ExecuteUsingParallelForeachAsync();
}
catch (Exception e)
{
	Console.WriteLine(e);
}

Console.ReadKey();

async Task ExecuteInSequence()
	=> (await _executor.ExecuteInSequence(_id)).Display();

async Task ExecuteInParallel() 
	=> (await _executor.ExecuteInParallel(_id)).Display();

async Task ExecuteUsingNormalForEach() 
	=> (await _executor.ExecuteUsingNormalForEach(_employeeIds!)).Display();

void ExecuteUsingParallelForeach() => _executor.ExecuteUsingParallelForeach(_employeeIds!).Display();

async Task ExecuteUsingParallelForeachAsync() => (await _executor.ExecuteUsingParallelForeachAsync(_employeeIds!)).Display();
