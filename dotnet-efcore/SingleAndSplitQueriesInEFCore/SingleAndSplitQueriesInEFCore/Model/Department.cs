namespace SingleAndSplitQueriesInEFCore.Model;

public class Department(int id, string name, int companyId)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public int CompanyId { get; private set; } = companyId;

    public Company Company { get; private set; } = null!;
}
