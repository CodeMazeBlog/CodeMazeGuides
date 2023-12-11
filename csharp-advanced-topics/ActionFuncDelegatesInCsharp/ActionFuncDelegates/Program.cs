public class Employee
{
    public int Id { get; set; }    
    public string Name { get; set; }    
}

public delegate bool DoTask(Employee employee);

class Program
{
    static void Main(string[] args)
    {
        var employee = new Employee { Id = 7, Name = "Jane Doe" };
        RunCustomDelegate(employee);
    }

    public static void RunCustomDelegate(Employee employee)
    {
        var updateDelegate = new DoTask(UpdateEmployee);
        var result = updateDelegate(employee);
    }

    static bool UpdateEmployee(Employee employee)
    {
        employee.Name += " Updated";
        return true;
    }
}


