using System.Linq.Dynamic.Core;
using SystemDynamicLinqCoreLibrary;

var employee = new Employee();
var employees = employee.GetEmployees();

var itDepartmentEmployees = employees.Where("Department == @0", "IT").ToList();

var itEmployees = employees.Where("Department == \"IT\"").ToList();

var itEmployeesList = employees.Where("c => c.Department = \"IT\"").ToList();

var relevantData = employees.Select("new {Name, Department}").ToDynamicList();

var sortedData = employees.OrderBy("Name").ToList();

var multipleSortedData = employees.OrderBy("Department desc, Name").ToList();

foreach (var itDepartmentEmployee in multipleSortedData)
{
    Console.WriteLine($"Name: {itDepartmentEmployee.Name}, Dept: {itDepartmentEmployee.Department}");
}