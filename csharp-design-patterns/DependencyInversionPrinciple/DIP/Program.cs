using DIP.Statistics;
using DIP.Storage;

var employeeManager = new EmployeeManager();
employeeManager.AddEmployee(new Employee("Leen", Gender.Female, Position.Manager));
employeeManager.AddEmployee(new Employee("Mike", Gender.Male, Position.Administrator));

var statistics = new EmployeeStatistics(employeeManager);

Console.WriteLine($"Number of female managers in our company is: {statistics.CountFemaleManagers()}");
