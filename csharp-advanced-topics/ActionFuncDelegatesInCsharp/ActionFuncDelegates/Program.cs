public class Employee
{
    public int Id { get; set; }    
    public string Name { get; set; }    
}

// Declaring the delegate
public delegate bool DoTask(Employee employee);

class Program
{
    static void Main(string[] args)
    {
        var employee = new Employee { Id = 7, Name = "Jane Doe" };
        RunCustomDelegate(employee);
        
        // Uncomment to run the Action delegate example
        // ActionDemo.RunDemo(employee);
        
        // Uncomment to run the Func delegate example
        // FuncDemo.RunDemo(employee);
    }

    public static void RunCustomDelegate(Employee employee)
    {
        // Let's instantiate and assign a method to the delegate
        var updateDelegate = new DoTask(UpdateEmployee);

        // Invoke the delegate which will call the UpdateEmployee method
        var result = updateDelegate(employee);
    }

    // This method will be assigned to the DoTask delegate
    static bool UpdateEmployee(Employee employee)
    {
        // Perform some operations to update the employee info
        employee.Name += " Updated";

        return true;
    }
}


