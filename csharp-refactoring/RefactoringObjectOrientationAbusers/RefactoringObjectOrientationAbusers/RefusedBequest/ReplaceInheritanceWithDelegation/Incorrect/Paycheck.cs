namespace RefactoringObjectOrientationAbusers.RefusedBequest.ReplaceInheritanceWithDelegation.Incorrect
{
    public class Paycheck
    {
        private readonly decimal _hourlyRate;
        private readonly int _hoursWorked;

        public Paycheck(decimal hourlyRate, int hoursWorked)
        {
            _hourlyRate = hourlyRate;
            _hoursWorked = hoursWorked;
        }

        public decimal CalculatePay()
        {
            return _hourlyRate * _hoursWorked;
        }
    }
}
