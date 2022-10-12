//var employeeDepartmentGroups = Employee.employees.GroupBy(x => x.Department);
//foreach (var group in employeeDepartmentGroups)
//{
//    System.Console.WriteLine("Department - " + group.Key + "\n-----------------------------------------------");
//    foreach (var employee in group)
//    {
//        System.Console.WriteLine(employee.Name);
//    }
//    Console.WriteLine("\n");
//}

//var employeeDepartmentGroups = Employee.employees.GroupBy(x => new { x.Department, x.Salary });

//foreach (var group in employeeDepartmentGroups)
//{
//    System.Console.WriteLine("Department, Salary - " + group.Key +
//        "\n-----------------------------------------------");
//    foreach (var employee in group)
//    {
//        System.Console.WriteLine(employee.Name);
//    }
//    Console.WriteLine("\n");
//}

//var employeeDepartmentGroups = Employee.employees.GroupBy(employee => 
//    {
//        var salaryLevel = employee.Salary < 50000 ? "Entry-Level" :
//                          employee.Salary >= 50000 && employee.Salary <= 85000 ? "Mid-Level" :
//                          "Senior-Level";

//        return salaryLevel;
//    });

//foreach (var group in employeeDepartmentGroups)
//{
//    System.Console.WriteLine("Salary - " + group.Key +
//        "\n-----------------------------------------------");
//    foreach (var employee in group)
//    {
//        System.Console.WriteLine(employee.Name);
//    }
//    Console.WriteLine("\n");
//}

//var employeeDepartmentGroupsAggReport = Employee.employees.GroupBy(employee =>
//{
//    var salaryLevel = employee.Salary < 50000 ? "Entry-Level" :
//                      employee.Salary >= 50000 && employee.Salary <= 85000 ? "Mid-Level" :
//                      "Senior-Level";

//    return salaryLevel;
//});

//Enumerable.Range(5, 10);
//Enumerable.Range(1, 10).Select(n => n * n);
//Enumerable.Range(5, 10).Where(n => n % 2 == 0);
//Enumerable.Range(1, 100).Select(_ => PerformSomeAction());

//Enumerable.Repeat(new Employee(), 100);

//var employeeDepartmentAggregateReport = Employee.employees.GroupBy(x => x.Department).Select(g => new
//{
//    Department = g.First().Department,
//    TotalDepartmentSalaryCosts = g.Sum(e => e.Salary)
//});

//Console.WriteLine("Department Salary Report\n");
//foreach (var departmentReport in employeeDepartmentAggregateReport)
//{
//    System.Console.WriteLine(departmentReport.Department + " - Total Salary - " + departmentReport.TotalDepartmentSalaryCosts +
//        "\n-----------------------------------------------");
//}

List<int> ints = new List<int>() { 2, 2, 2, 4, 5, 8, 9, 6, 1, 8, 9, 7 };

ints.SkipWhile()

public class Employee
{
    public int EmployeeId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public double Salary { get; set; } = 0.0;

    public static List<Employee> employees = new List<Employee>()
        {
            new() { EmployeeId = 1, Name = "Alvin Johnston", Department = "Sales", Salary = 55000.00 },
            new() { EmployeeId = 2, Name = "Jessica Cuevas", Department = "Engineering", Salary = 65000.00 },
            new() { EmployeeId = 3, Name = "Grace Silver", Department = "Sales", Salary = 75000.00 },
            new() { EmployeeId = 4, Name = "Justin Vilches", Department = "Engineering", Salary = 85000.00 },
            new() { EmployeeId = 5, Name = "Joey Delgado", Department = "IT", Salary = 85000.00 },
            new() { EmployeeId = 6, Name = "Ashley Montoya", Department = "Engineering", Salary = 85000.00 },
            new() { EmployeeId = 7, Name = "Silvio Mora", Department = "IT", Salary = 85000.00 },
            new() { EmployeeId = 8, Name = "Arjen Robben", Department = "Administration", Salary = 105000.00 },
            new() { EmployeeId = 9, Name = "Mohammad Salah", Department = "Administration", Salary = 115000.00 },
            new() { EmployeeId = 10, Name = "Nasir Jones", Department = "Customer Service", Salary = 45000.00 },
        };
}