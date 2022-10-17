using BenchmarkDotNet.Running;
using ObjectComparisons;

Employee[] employees = new Employee[5]
    {
        new Employee(4, "John"),
        new Employee(2, "Tom"),
        new Employee(1, "Eric"),
        new Employee(5, "Dan"),
        new Employee(3, "Alen")
    };

Console.WriteLine("The Employee Array:");

PrintEmployees(employees);

Array.Sort(employees);

Console.WriteLine("\nDefault Sorting:");

PrintEmployees(employees);

Array.Sort(employees, Employee.SortByIdAscending());

Console.WriteLine("\nSorting by Id Ascending");

PrintEmployees(employees);

Array.Sort(employees, Employee.SortByIdDescending());

Console.WriteLine("\nSorting by Id Descending");

PrintEmployees(employees);

List<Employee> employeeList = new List<Employee>
    {
        new Employee(4, "John"),
        new Employee(2, "Tom"),
        new Employee(1, "Eric"),
        new Employee(5, "Dan"),
        new Employee(3, "Alen")
    };

employeeList.Sort(Employee.CompareEmployeesByIdAscending);

Console.WriteLine("\nSorting by Id Ascending using Comparison Delegate");

PrintEmployeeList(employeeList);

employeeList.Sort(Employee.CompareEmployeesByIdDescending);

Console.WriteLine("\nSorting by Id Descending using Comparison Delegate");

PrintEmployeeList(employeeList);

BenchmarkRunner.Run<ObjectComparisonBenchmark>();

static void PrintEmployees(Employee[] employees)
{
    foreach (var employee in employees)
    {
        Console.WriteLine(employee.Id + "\t\t" + employee.Name);
    }
}

static void PrintEmployeeList(List<Employee> employees)
{
    foreach (var employee in employees)
    {
        Console.WriteLine(employee.Id + "\t\t" + employee.Name);
    }
}