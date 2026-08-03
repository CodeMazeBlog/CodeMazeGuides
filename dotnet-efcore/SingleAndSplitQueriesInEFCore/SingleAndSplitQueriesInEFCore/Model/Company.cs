namespace SingleAndSplitQueriesInEFCore.Model;

public class Company(int id, string name)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;

    public List<Department> Departments { get; } = new();
    public List<Product> Products { get; } = new();
}
