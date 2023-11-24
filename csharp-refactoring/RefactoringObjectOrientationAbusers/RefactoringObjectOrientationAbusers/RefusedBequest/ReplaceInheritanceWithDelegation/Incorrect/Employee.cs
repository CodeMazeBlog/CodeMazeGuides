namespace RefactoringObjectOrientationAbusers.RefusedBequest.ReplaceInheritanceWithDelegation.Incorrect
{
    public class Employee : Paycheck
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Employee(decimal hourlyRate, int hoursWorked)
            : base(hourlyRate, hoursWorked)
        {
        }
    }
}
