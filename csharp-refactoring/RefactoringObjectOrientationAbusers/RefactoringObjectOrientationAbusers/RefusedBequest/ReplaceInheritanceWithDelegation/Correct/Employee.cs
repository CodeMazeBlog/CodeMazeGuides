namespace RefactoringObjectOrientationAbusers.RefusedBequest.ReplaceInheritanceWithDelegation.Correct
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private readonly Paycheck _paycheck;

        public Employee(Paycheck paycheck)
        {
            _paycheck = paycheck;
        }

        public decimal CalculatePay()
        {
            return _paycheck.CalculatePay();
        }
    }
}
