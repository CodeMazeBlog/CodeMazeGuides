// See https://aka.ms/new-console-template for more information
var employee = new
{
    Id = 001,
    FirstName = "John",
    LastName = "Doe",
    Department = "Marketing",
    FullTime = false,
    HourlyPay = 35.75
};

Console.WriteLine($"Id: {employee.Id}");
Console.WriteLine($"First Name: {employee.FirstName}");
Console.WriteLine($"Last Name: {employee.LastName}");
Console.WriteLine($"Department: {employee.Department}");
Console.WriteLine($"Full Time: {employee.FullTime}");
Console.WriteLine($"Hourly Pay: {employee.HourlyPay}");

Console.WriteLine(); Console.WriteLine();

Console.WriteLine($"Id Type: {employee.Id.GetType()}");
Console.WriteLine($"First Name Type: {employee.FirstName.GetType()}");
Console.WriteLine($"Last Name Type: {employee.LastName.GetType()}");
Console.WriteLine($"Department Type: {employee.Department.GetType()}");
Console.WriteLine($"Full Time Type: {employee.FullTime.GetType()}");
Console.WriteLine($"Hourly Pay Type: {employee.HourlyPay.GetType()}");

Console.WriteLine(); Console.WriteLine();

var employeeWithOfficeAddress = new
{
    Id = 0002,
    FirstName = "Jane",
    LastName = "Doe",
    Department = "Accounting",
    OfficeAddress = new
    {
        Street = "123 Green St.",
        City = "Atlanta",
        State = "Georgia",
        Country = "USA"
    }
};

Console.WriteLine($"Employee Office Location: {employeeWithOfficeAddress.OfficeAddress.City}");

Console.WriteLine(); Console.WriteLine();

var arrEmployees = new[]
{
    new { Id = 001, FirstName = "John", LastName = "Doe", Department = "Marketing" },
    new { Id = 002, FirstName = "Jane", LastName = "Doe", Department = "Accounting" },
    new { Id = 003, FirstName = "Bob", LastName = "Smith", Department = "Human Resources" }
};

foreach (var emp in arrEmployees)
{
    Console.WriteLine($"Id: {emp.Id} Name: {emp.FirstName} {emp.LastName}");
}

Console.WriteLine(); Console.WriteLine();

dynamic dynamicEmployee = new
{
    Id = 001,
    FirstName = "John",
    LastName = "Doe",
};

Console.WriteLine($"Id: {dynamicEmployee.Id}");
Console.WriteLine($"Name: {dynamicEmployee.FirstName} {dynamicEmployee.LastName}");

Console.WriteLine(); Console.WriteLine();

List<Employee> EmployeeList = new List<Employee>() {
            new Employee() { Id = 001, FirstName = "John", LastName = "Doe", Department = "Marketing" },
            new Employee() { Id = 002, FirstName = "Jane", LastName = "Doe", Department = "Accounting" },
            new Employee() { Id = 003, FirstName = "Bob", LastName = "Smith", Department = "Human Resources" }
        };

var employeesFromList = from emp in EmployeeList
                        select new { Id = emp.Id, Name = $"{emp.FirstName} {emp.LastName}" };

foreach (var emp in employeesFromList)
    Console.WriteLine($"Id: {emp.Id} Name: {emp.Name}");

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
}