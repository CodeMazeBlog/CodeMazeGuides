namespace ActionFuncDelegates;

public class FuncDemo
{
    public static void RunDemo(Employee employee)
    {
        Func<Employee, bool> updateDelegate = UpdateEmployee;
        var result = updateDelegate(employee);
    }

    static bool UpdateEmployee(Employee employee)
    {
        employee.Name += " Updated";
        return true;
    }
}

