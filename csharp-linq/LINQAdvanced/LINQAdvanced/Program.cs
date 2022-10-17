using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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

//List<int> ints = new List<int>() { 2, 2, 2, 4, 5, 8, 9, 6, 1, 8, 9, 7 };

//List<Employee> emp = new List<Employee>()
//{
//    new Director() { 
//        AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 1,
//        Name = "Rodrigo Suarez", Department = "Leadership", Salary = 175000.00
//    },
//    new() { EmployeeId = 2, Name = "Jessica Cuevas", Department = "Engineering", Salary = 65000.00 },
//    new() { EmployeeId = 7, Name = "Silvio Mora", Department = "IT", Salary = 85000.00 },
//    new Administrator() { AbleToFire = false, EmployeeId = 8, Name = "Arjen Robben", Department = "Administration", Salary = 105000.00 },
//    new Administrator() { AbleToFire = true, EmployeeId = 9, Name = "Mohammad Salah", Department = "Administration", Salary = 115000.00 },
//    new() { EmployeeId = 10, Name = "Nasir Jones", Department = "Customer Service", Salary = 45000.00 },
//};

//var admins = emp.OfType<Administrator>();
//admins.ToList().ConvertAll(d => JsonSerializer.Serialize(d));

var directors = new List<Director>()
{
    new Director() {
        AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 100,
        Name = "Rodrigo Suarez", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "Sales"
    },
    new Director() {
        AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 101,
        Name = "Nikola Jokic", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "Engineering"
    },
    new Director() {
        AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 102,
        Name = "Petr Cech", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "IT"
    },
    new Director() {
        AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 103,
        Name = "Clown boy bob", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "Clown"
    },
};

//var join = Employee.employees.Join(directors, 
//                                    em => em.Department,
//                                    dir => dir.DepartmentResponsibleFor,
//                                    (em, dir) => new { EmployeeName = em.Name, DirectorName = dir.Name, Department = em.Department });

//foreach (var item in join.OrderBy(j => j.Department))
//{
//    Console.WriteLine($"Department:{item.Department}\n--------\nEmployeeName:{item.EmployeeName}\nDirectorName:{item.DirectorName}\n");
//}

// composite keys can have differently named properties
//// return object cant have the same named properties
//var compositeJoin = Employee.employees.Join(directors,
//                                            em => new { em.Department, em.Salary },
//                                            dir => new { Department = dir.DepartmentResponsibleFor, dir.Salary },
//                                            (em, dir) => new { em.Name, OtherName = dir.Name });

//foreach (var item in compositeJoin)
//{
//    Console.WriteLine($"--------\nEmployeeName:{item.Name}\nDirectorName:{item.OtherName}\n");
//}

//var groupJoin = Employee.employees.GroupJoin(directors,
//                                            em => em.Department,
//                                            dir => dir.DepartmentResponsibleFor,
//                                            (em, dirGroup) => new { em.Name, dirGroup = dirGroup });

//var groupJoin = directors.GroupJoin(Employee.employees,
//                                    dir => dir.DepartmentResponsibleFor,
//                                    em => em.Department,
//                                    (dir, emGroup) => new {dir.Name, EmployeeGroup = emGroup });

//foreach (var dir in groupJoin)
//{
//    Console.WriteLine($"DirectorName:{dir.Name}");
//    foreach (var emp in dir.EmployeeGroup)
//    {
//        Console.WriteLine($"\nEmployeeName:{emp.Name}\n");
//    }
//    Console.WriteLine("---------------\n");
//}

var groupJoin = directors.GroupJoin(Employee.employees,
                                    dir => dir.DepartmentResponsibleFor,
                                    em => em.Department,
                                    (dir, emGroup) => new { dir.DepartmentResponsibleFor, dir.Name, EmployeeGroup = emGroup.DefaultIfEmpty(new() { Name = "No Name" }) });

foreach (var dir in groupJoin)
{
    Console.WriteLine($"Department: {dir.DepartmentResponsibleFor} -- Director:{dir.Name}");
    foreach (var emp in dir.EmployeeGroup)
    {
        Console.WriteLine($"\nEmployee:{emp.Name}\n");
    }
    Console.WriteLine("---------------\n");
}

Console.WriteLine();

public class Director : Employee
{
    public string Permissions { get; set; } = string.Empty;
    public bool AbleToHire { get; set; } = false;
    public string DepartmentResponsibleFor { get; set; } = string.Empty;
}

public class Administrator : Employee
{
    public bool AbleToFire { get; set; } = false;
}

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