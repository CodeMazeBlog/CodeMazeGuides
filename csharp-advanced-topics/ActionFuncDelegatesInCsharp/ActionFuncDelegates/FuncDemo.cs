namespace ActionFuncDelegates;

public class FuncDemo
{
    public static void RunDemo(Employee employee)
    {
        // Let's instantiate and assign a method to the delegate
        Func<Employee, bool> updateDelegate = UpdateEmployee;

        // Invoke the delegate which will call the UpdateEmployee method
        var result = updateDelegate(employee);
    }

    // This method will be assigned to the DoTask delegate
    static bool UpdateEmployee(Employee employee)
    {
        employee.Name += " Updated";
        return true;
    }
}

