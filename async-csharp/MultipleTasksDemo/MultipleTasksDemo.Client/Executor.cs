using System.Collections.Concurrent;
using System.Diagnostics;
using MultipleTasksDemo.Client.Contracts;
using TaskExtensions = MultipleTasksDemo.Client.Extensions.TaskExtensions;

namespace MultipleTasksDemo.Client;

public class Executor
{
    private readonly IEmployeeApiFacade _employeeApiFacade;

    public Executor(IEmployeeApiFacade employeeApiFacade)
    {
        _employeeApiFacade = employeeApiFacade;
    }

    public async Task<EmployeeProfile> ExecuteInSequence(Guid id)
    {   
        var employeeDetails = await _employeeApiFacade.GetEmployeeDetails(id);
        var employeeSalary = await _employeeApiFacade.GetEmployeeSalary(id);
        var employeeRating = await _employeeApiFacade.GetEmployeeRating(id);        

        return new EmployeeProfile(employeeDetails, employeeSalary, employeeRating);
    }

    public async Task<EmployeeProfile> ExecuteInParallel(Guid id)
    {      
        var employeeDetailsTask = _employeeApiFacade.GetEmployeeDetails(id);
        var employeeSalaryTask = _employeeApiFacade.GetEmployeeSalary(id);
        var employeeRatingTask = _employeeApiFacade.GetEmployeeRating(id);

        //await Task.WhenAll(employeeDetailsTask, employeeSalaryTask, employeeRatingTask);

        //var employeeDetails = await employeeDetailsTask;
        //var employeeSalary = await employeeSalaryTask;
        //var employeeRating = await employeeRatingTask;

        var (employeeDetails, employeeSalary, employeeRating) = await TaskExtensions.WhenAll(employeeDetailsTask, employeeSalaryTask, employeeRatingTask);        

        return new EmployeeProfile(employeeDetails, employeeSalary, employeeRating);
    }

    public async Task<IEnumerable<EmployeeDetails>> ExecuteUsingNormalForEach(IEnumerable<Guid> employeeIds)
    {            
        List<EmployeeDetails> employeeDetails = new();
        
        foreach (var id in employeeIds)
        {
            var employeeDetail = await _employeeApiFacade.GetEmployeeDetails(id);

            employeeDetails.Add(employeeDetail);
        }        

        return employeeDetails;
    }

    public IEnumerable<EmployeeDetails> ExecuteUsingParallelForeach(IEnumerable<Guid> employeeIds)
    {
        ParallelOptions parallelOptions = new()
        {
            MaxDegreeOfParallelism = 3
        };        

        ConcurrentBag<EmployeeDetails> employeeDetails = new();

        Parallel.ForEach(employeeIds, parallelOptions, id =>
        {
            var employeeDetail = _employeeApiFacade.GetEmployeeDetails(id).GetAwaiter().GetResult();

            employeeDetails.Add(employeeDetail);
        });        

        return employeeDetails;
    }

    public async Task<IEnumerable<EmployeeDetails>> ExecuteUsingParallelForeachAsync(IEnumerable<Guid> employeeIds)
    {
        ParallelOptions parallelOptions = new()
        {
            MaxDegreeOfParallelism = 3
        };       

        ConcurrentBag<EmployeeDetails> employeeDetails = new();

        await Parallel.ForEachAsync(employeeIds, parallelOptions, async (id, _) =>
        {
            var employeeDetail = await _employeeApiFacade.GetEmployeeDetails(id);

            employeeDetails.Add(employeeDetail);
        });        

        return employeeDetails;
    }
}