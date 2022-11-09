using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using SystemDynamicLinqCoreLibrary;


var employeeData = new EmployeeData();
var employees = employeeData.GetEmployees();

var stronglyTypedEmployeeLinq = employees
    .Where(e => e.Department == "IT")
    .ToList();

var itDepartmentEmployees = employees
    .Where("Department == @0", "IT")
    .ToList();

var itEmployees = employees
    .Where("Department == \"IT\"")
    .ToList();

var itEmployeesList = employees
    .Where("c => c.Department = \"IT\"")
    .ToList();

var stronglyTypedSelect = employees
    .Select(e => new Employee
    {
        Name = e.Name,
        Department = e.Department,
    })
    .ToList();


var relevantData = employees
    .Select("new {Name, Department}")
    .ToDynamicList();

var sortedData = employees
    .OrderBy("Name")
    .ToList();

var stronglySortedData = employees
    .OrderBy(x => x.Name)
    .ToList();

var strongMultipleSortedData = employees
    .OrderBy(x => x.Department)
    .ThenBy(x => x.Name)
    .ToList();

var multipleSortedData = employees
    .OrderBy("Department desc, Name")
    .ToList();


// Creating Config

var config = new ParsingConfig()
{
    DateTimeIsParsedAsUTC = true
};

var query = employees
    .Where(config, "Age > 26")
    .ToList();

// Null Propagation

var employeeNullPropagation = employees
    .Where("np(Employer.Name) == \"Test Company\"")
    .ToList();

var employeesUnknownEmployer = employees
    .ToDynamicList();


// Dynamic Lambda Expressions

Expression<Func<Employee, bool>> itExpression = DynamicExpressionParser
    .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Department = @0", "IT");

Expression<Func<Employee, bool>> ageExpression = DynamicExpressionParser
    .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Age >= 20");

var employeesLambda = employees
    .Where("@0(it) and @1(it)", itExpression, ageExpression)
    .ToList();