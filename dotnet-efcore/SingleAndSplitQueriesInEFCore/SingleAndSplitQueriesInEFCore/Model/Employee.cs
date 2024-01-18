namespace SingleAndSplitQueriesInEFCore.Model;

public class Employee(int id, string name, int departmentId)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public int DepartmentId { get; private set; } = departmentId;

    public Department Department { get; private set; } = null!;
}
