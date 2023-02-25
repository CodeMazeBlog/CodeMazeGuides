namespace AccessModifiersInCsharp
{
    public class Employee
    {
        private protected int EmployeeId { get; set; }
        private protected string Name { get; set; }
        private protected double Salary { get; set; }        

        public virtual string GetEmployeeDetails()
        {
            return $"Employee ID: {EmployeeId}, Name: {Name}, Salary: {Salary}";
        }
    }
}
