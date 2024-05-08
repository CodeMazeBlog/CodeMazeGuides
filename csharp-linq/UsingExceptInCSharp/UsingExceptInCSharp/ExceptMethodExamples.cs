namespace UsingExceptInCSharp;

public class ExceptMethodExamples
{
    List<Employee> Employees = new()
    {
        new Employee {ID =  1, Name = "John Doe", Age = 28, Department = "Sales"},
        new Employee {ID =  2, Name = "Emily Sanders", Age = 29, Department = "Sales"},
        new Employee {ID =  3, Name = "Benjamin Winters", Age = 30, Department = "Sales"},
        new Employee {ID =  4, Name = "Sheila Foxx", Age = 31, Department = "Marketing"},
        new Employee {ID =  5, Name = "Alexander Flemming", Age = 31, Department = "Marketing"},
        new Employee {ID =  6, Name = "Grace Jones", Age = 32, Department = "IT"},
        new Employee {ID =  7, Name = "Ava Knowles", Age = 32, Department = "IT"},
        new Employee {ID =  8, Name = "Isabela Wambui", Age = 48, Department = "Marketing"},
        new Employee {ID =  9, Name = "David Otieno", Age = 60, Department = "HR"},
        new Employee {ID =  10, Name = "Emma Charlotte", Age = 33, Department = "HR"},
        new Employee {ID =  11, Name = "Michael Bay", Age = 34, Department = "HR"},
        new Employee {ID =  12, Name = "Mary Jane", Age = 35, Department = "Sales"}
    };

    List<Employee> SalesEmployees = new()
    {
        new Employee {ID =  1, Name = "John Doe", Age = 28, Department = "Sales"},
        new Employee {ID =  2, Name = "Emily Sanders", Age = 29, Department = "Sales"},
        new Employee {ID =  3, Name = "Benjamin Winters", Age = 30, Department = "Sales"},
        new Employee {ID =  12, Name = "Mary Jane", Age = 35, Department = "Sales"}
    };

    List<Employee> ITEmployees = new()
    {

        new Employee {ID =  6, Name = "grace jones", Age = 32, Department = "IT"},
        new Employee {ID =  7, Name = "ava knowles", Age = 32, Department = "IT"}
    };

    public List<Employee> GetEmployeesNotInSales()
    {
        var employeesNotInSales = Employees.Select(e => new { e.ID, e.Name, e.Age, e.Department })
                    .Except(SalesEmployees.Select(s => new { s.ID, s.Name, s.Age, s.Department })).ToList();

        var list = employeesNotInSales.Select(x => new Employee
        {
            ID = x.ID,
            Name = x.Name,
            Age = x.Age,
            Department = x.Department
        }).ToList();

        return list;
    }

    public List<string> GetEmployeesNotInITIgnoreCase()
    {
        var employeesNotInIT = Employees.Select(e => e.Name).Except(ITEmployees.Select(s => s.Name), StringComparer.OrdinalIgnoreCase).ToList();

        return employeesNotInIT;
    }

    public List<Employee> GetEmployeesNotInSalesUsingComparer() 
    {
        EmployeeComparer comparer = new ();

        return Employees.Except(SalesEmployees, comparer).ToList();
    }
}
