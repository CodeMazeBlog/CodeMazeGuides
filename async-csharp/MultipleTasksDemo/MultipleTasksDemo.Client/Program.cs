using System.Diagnostics;
using System.Text;
using System.Text.Json;
using MultipleTasksDemo.Client;
using MultipleTasksDemo.Client.Contracts;
using TaskExtensions = MultipleTasksDemo.Client.TaskExtensions;

HttpClient _httpClient = new();
var _id = new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e");
var _serializerOptions = new JsonSerializerOptions
                         {
                             PropertyNameCaseInsensitive = true
                         };

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
{
    var stopWatch = Stopwatch.StartNew();

    var employeeDetails = await GetEmployeeDetails(_id);
    var employeeSalary = await GetEmployeeSalary(_id);
    var employeeRating = await GetEmployeeRating(_id);

    Console.WriteLine($"Sequential Execution completed in {stopWatch.ElapsedMilliseconds}");

    var employeeProfile = new EmployeeProfile(employeeDetails, employeeSalary, employeeRating);

    //To show euro sign
    Console.OutputEncoding = Encoding.Default;
    Console.WriteLine(employeeProfile.ToString());

}

async Task ExecuteInParallel()
{
    var stopWatch = Stopwatch.StartNew();

    var employeeDetailsTask =  GetEmployeeDetails(_id);
    var employeeSalaryTask =   GetEmployeeSalary(_id);
    var employeeRatingTask =   GetEmployeeRating(_id);

    //await Task.WhenAll(employeeDetailsTask, employeeSalaryTask, employeeRatingTask);

    //var employeeDetails = await employeeDetailsTask;
    //var employeeSalary = await employeeSalaryTask;
    //var employeeRating = await employeeRatingTask;

    var (employeeDetails, employeeSalary, employeeRating) = await TaskExtensions.WhenAll(employeeDetailsTask, employeeSalaryTask, employeeRatingTask);

    Console.WriteLine($"Parallel Execution completed in {stopWatch.ElapsedMilliseconds}");

    var employeeProfile = new EmployeeProfile(employeeDetails, employeeSalary, employeeRating);

    //To show euro sign
    Console.OutputEncoding = Encoding.Default;
    Console.WriteLine(employeeProfile.ToString());
}

async Task ExecuteUsingNormalForEach()
{
    var stopWatch = Stopwatch.StartNew();

    foreach (var id in _employeeIds)
    {
        var employeeDetail = await GetEmployeeDetails(id);

        Console.WriteLine($"Id: {employeeDetail.Id}\nName: {employeeDetail.Name}\nDOB: {employeeDetail.DateOfBirth}\n");
    }
                                                        
    Console.WriteLine($"Normal ForEach Execution completed in {stopWatch.ElapsedMilliseconds}");
}

void ExecuteUsingParallelForeach()
{
    ParallelOptions parallelOptions = new()
                                      {
                                          MaxDegreeOfParallelism = 3
                                      };
    var stopWatch = Stopwatch.StartNew();

    Parallel.ForEach(_employeeIds, parallelOptions,  id =>
                                                               {
                                                                   var employeeDetail = GetEmployeeDetails(id).GetAwaiter().GetResult();

                                                                   Console.WriteLine($"Id: {employeeDetail.Id}\nName: {employeeDetail.Name}\nDOB: {employeeDetail.DateOfBirth}\n");
                                                               });

    Console.WriteLine($"Parallel ForEach Execution completed in {stopWatch.ElapsedMilliseconds}");
}

async Task ExecuteUsingParallelForeachAsync()
{
    ParallelOptions parallelOptions = new()
                                      {
                                          MaxDegreeOfParallelism = 3
                                      };
    var stopWatch = Stopwatch.StartNew();

    await Parallel.ForEachAsync(_employeeIds, parallelOptions, async (id, _) =>
                                                               {
                                                                   var employeeDetail = await GetEmployeeDetails(id);

                                                                   Console.WriteLine($"Id: {employeeDetail.Id}\nName: {employeeDetail.Name}\nDOB: {employeeDetail.DateOfBirth}\n");
                                                               });

    Console.WriteLine($"Parallel ForEachAsync Execution completed in {stopWatch.ElapsedMilliseconds}");

}

async Task<EmployeeDetails> GetEmployeeDetails(Guid id)
{
	var response = await _httpClient.GetStringAsync($"http://localhost:3000/details/{id}");
    var employeeDetails = JsonSerializer.Deserialize<EmployeeDetails>(response, _serializerOptions);
    await Task.Delay(2000);
    //throw new Exception("Test Exception 1");
    return employeeDetails!;
}

async Task<decimal> GetEmployeeSalary(Guid id)
{
	var response = await _httpClient.GetStringAsync($"http://localhost:3000/salary/{id}");
    var salary = JsonSerializer.Deserialize<Salary>(response, _serializerOptions);
    await Task.Delay(1000);
    //throw new Exception("Test Exception 2");
    return salary!.SalaryInEuro;
}

async Task<int> GetEmployeeRating(Guid id)
{
	var response = await _httpClient.GetStringAsync($"http://localhost:3000/rating/{id}");
    var rating = JsonSerializer.Deserialize<AppraisalRating>(response, _serializerOptions);
    await Task.Delay(1000);
    return rating!.Rating;
}

