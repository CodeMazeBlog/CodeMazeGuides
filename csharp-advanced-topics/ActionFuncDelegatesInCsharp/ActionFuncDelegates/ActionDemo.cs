namespace ActionFuncDelegates;

public class ActionDemo
{
    public static void RunDemo(Employee employee)
    {
        // Let's instantiate and assign a method to the delegate
        Action<Employee> updateDelegate = UpdateEmployee;

        // Invoke the delegate which will call the UpdateEmployee method
        updateDelegate(employee);
    }

    // This method will be assigned to the DoTask delegate
    static void UpdateEmployee(Employee employee)
    {
        employee.Name += " Updated";
    }
}