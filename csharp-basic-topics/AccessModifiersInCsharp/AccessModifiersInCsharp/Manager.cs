namespace AccessModifiersInCsharp
{
    public class Manager : Employee
    {
        public override string GetEmployeeDetails()
        {
            EmployeeId = 1;
            Name = "Jacob";
            Salary = 90000;

            //var employee = new Employee();
            //employee.EmployeeId = 2;

            return $"Manager Details: {base.GetEmployeeDetails()}";
        }
    }
}
