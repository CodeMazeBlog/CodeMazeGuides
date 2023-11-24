using MultipleTasksDemo.Client.Contracts;

namespace MultipleTasksDemo.Client;

public interface IEmployeeApiFacade
{
    public Task<EmployeeDetails> GetEmployeeDetails(Guid id);

    public Task<decimal> GetEmployeeSalary(Guid id);

    public Task<int> GetEmployeeRating(Guid id);
}