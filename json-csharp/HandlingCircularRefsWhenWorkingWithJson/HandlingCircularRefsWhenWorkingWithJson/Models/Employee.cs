using System.Collections.ObjectModel;

namespace HandlingCircularRefsWhenWorkingWithJson.Models;

public class Employee
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Title { get; set; }
    public Employee? Manager { get; set; }
    public Collection<Employee> DirectReports { get; set; } = new Collection<Employee>();
}