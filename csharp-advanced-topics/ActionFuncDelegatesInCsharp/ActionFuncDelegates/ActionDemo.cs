namespace ActionFuncDelegates;

public class ActionDemo
{
    public static void RunDemo(Employee employee)
    {
        Action<Employee> updateDelegate = UpdateEmployee;
        updateDelegate(employee);
    }

    static void UpdateEmployee(Employee employee)
    {
        employee.Name += " Updated";
    }
}