namespace DelegateApp
{
    public enum EmployeeType
    {
        FullTime,
        PartTime,
        Contractual
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
