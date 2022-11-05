using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using SystemDynamicLinqCoreLibrary;

var employee = new Employee();

var employees = employee.GetEmployees();

var itDepartmentEmployees = employees.Where("Department == @0", "IT").ToList();

var itEmployees = employees.Where("Department == \"IT\"").ToList();

var itEmployeesList = employees.Where("c => c.Department = \"IT\"").ToList();

var relevantData = employees.Select("new {Name, Department}").ToDynamicList();

var sortedData = employees.OrderBy("Name").ToList();

var multipleSortedData = employees.OrderBy("Department desc, Name").ToList();


// Creating Config

var config = new ParsingConfig()
{
    DateTimeIsParsedAsUTC = true
};

var query = employees.Where(config, "Age > 26").ToList();

// Null Propagation

var employeeNullPropagation = employees.Where("np(Employer.Name) == \"Block 10\"").ToList();

var employeesUnknownEmployer = employees.Select("np(Employer.Name, \"Not Specified\")").ToDynamicList();


// Dynamic Lambda Expressions

Expression<Func<Employee, bool>> itExpression = DynamicExpressionParser
    .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Department = @0", "IT");

Expression<Func<Employee, bool>> ageExpression = DynamicExpressionParser
    .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Age >= 20");

var employeesLambda = employees.Where("@0(it) and @1(it)", itExpression, ageExpression).ToList();
