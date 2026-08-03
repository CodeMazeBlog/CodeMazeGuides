namespace SelectMultipleRecordsUsingLinqCSharp;

public class EmployeeRepository(CompanyDbContext dbContext)
{
    private readonly CompanyDbContext _dbContext = dbContext;

    public List<Employee> GetEmployeesUsingWhere(IList<int> ids)
    {
        var query = _dbContext.Employees.Where(e => ids.Contains(e.Id));

        return [.. query];
    }

    public List<Employee> GetEmployeesUsingWhere(HashSet<int> ids)
    {
        var query = _dbContext.Employees.Where(e => ids.Contains(e.Id));

        return [.. query];
    }

    public List<Employee> GetEmployeesUsingJoin(IList<int> ids)
    {
        var query = _dbContext.Employees.Join(ids, e => e.Id, id => id, (e, id) => e);

        return [.. query];
    }

    public List<Employee> GetEmployeesUsingJoin(HashSet<int> ids)
    {
        var query = _dbContext.Employees.Join(ids, e => e.Id, id => id, (e, id) => e);

        return [.. query];
    }
}
