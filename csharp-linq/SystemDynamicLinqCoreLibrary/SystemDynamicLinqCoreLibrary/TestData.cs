using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace SystemDynamicLinqCoreLibrary;

public class TestData
{
    private readonly EmployeeData _employeeData = new();
    public IQueryable<Employee> Employees { get; set; }

    public TestData() => Employees = _employeeData.Employees;

    public List<Employee> FilterEmployeesByDepartmentUsingTypedLinq(string departmentName) =>
        Employees
            .Where(e => e.Department == departmentName)
            .ToList();

    public List<Employee> FilterEmployeesByDepartment(string departmentName) =>
        Employees
            .Where("Department == @0", departmentName)
            .ToList();

    public List<Employee> FilterEmployeesUsingEscapeSequence() =>
        Employees
            .Where("Department == \"IT\"")
            .ToList();

    public List<Employee> FilterEmployeesUsingLambdaOperator() =>
        Employees
            .Where("c => c.Department = \"IT\"")
            .ToList();


    public List<dynamic> SelectEmployees() =>
        Employees
            .Select("new {Name, Department}")
            .ToDynamicList();

    public List<Employee> SelectEmployeesUsingTypedLinq() =>
        Employees
            .Select(e => new Employee
            {
                Name = e.Name,
                Department = e.Department,
            })
            .ToList();

    public List<Employee> SortEmployeesUsingTypedLinq() =>
        Employees
            .OrderBy(x => x.Name)
            .ToList();

    public List<Employee> SortEmployees() =>
        Employees
            .OrderBy("Name")
            .ToList();

    public List<Employee> SortEmployeesByMultipleProperties() =>
        Employees
            .OrderBy("Department desc, Name")
            .ToList();

    public List<Employee> SortEmployeesByMultiplePropertiesUsingTypedLinq() =>
        Employees
            .OrderBy(x => x.Department)
            .ThenBy(x => x.Name)
            .ToList();

    public List<Employee> GetEmployeesByEmployer(string employer) =>
        Employees
            .Where("np(Employer.Name) == @0", employer)
            .ToList();

    public List<dynamic> GetEmployeesWhereEmployerIsNull() =>
        Employees
            .Select("np(Employer.Name, \"Not Specified\")")
            .ToDynamicList();

    public List<Employee> CreateDynamicLambdaExpressions(string department, int age)
    {
        Expression<Func<Employee, bool>> itExpression = DynamicExpressionParser
            .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Department = @0", department);

        Expression<Func<Employee, bool>> ageExpression = DynamicExpressionParser
            .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Age >= @0", age);

        return Employees
            .Where("@0(it) and @1(it)", itExpression, ageExpression)
            .ToList();
    }
}