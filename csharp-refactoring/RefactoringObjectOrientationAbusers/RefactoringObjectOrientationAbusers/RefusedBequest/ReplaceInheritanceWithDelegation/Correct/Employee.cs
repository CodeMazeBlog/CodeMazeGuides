namespace RefactoringObjectOrientationAbusers.RefusedBequest.ReplaceInheritanceWithDelegation.Correct
{
    public class Employee
    {
        private readonly Paycheck _paycheck;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


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
